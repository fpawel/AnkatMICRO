﻿module Ankat.PartyWorks

open System

open Thread2
open Pneumo

open ViewModel.Operations

[<AutoOpen>]
module private Helpers = 
    type P = Product
    let party = AppContent.party
    let appCfg = AppConfig.config
    let viewCfg = appCfg.View


let checkedProducts() = 
    party.Products
    |> Seq.filter( fun p -> p.IsChecked )
let hasNotCheckedProduct() = checkedProducts() |> Seq.isEmpty 
let hasCheckedProduct() = not <| hasNotCheckedProduct()


let doWithProducts f = 
    checkedProducts() |> Seq.iter ( fun p ->       
        if isKeepRunning() && p.IsChecked then 
            f p ) 

type Ankat.ViewModel.Product1 with
    
    member x.WriteKef (kef,value) =         
        let value =
            match value, P.getKef kef x.Product with
            | Some value, _ -> Some value
            | _, Some value -> Some  value            
            | _ ->  None
        match value with
        | None -> 
            Logging.warn "%s, нет значения записываемого к-та %d, %s" x.What kef.Order kef.Description 
            Ok()
        | Some value -> x.WriteModbus( WriteKef kef, value )

    
    member x.WriteKefs kefsValues  = 
        for kef,value in kefsValues do
            let _ = x.WriteKef(kef,value)
            () 
        None
            
    member x.WriteKefsInitValues() = 
        let t = party.getProductType()        
        [   yield Coef.SER_NUMBER, decimal x.Product.SerialNumber
            yield! Alchemy.initKefsValues party.GetPgs t ]
        |> List.sortBy fst
        |> List.map( fun (coef,value) -> coef, Some value )
        |> x.WriteKefs

    member x.ReadKefs kefs = maybeErr {
        for kef in kefs do
            let r = x.ReadModbus( ReadKef kef )
            match r with
            | Ok value -> 
                Logging.info "%s.коэф.%d = %M" x.What kef.Order value
                x.setKef kef (Some value) 
            | Err err ->
                Logging.error "%s.коэф.%d : %s" x.What kef.Order err 
            let _ = r
            () }

    
    member x.Interrogate() = maybeErr {
        let xs = 
            let xs = AppConfig.config.View.VisiblePhysVars
            if Set.isEmpty xs then [Sens1.Conc] else
            Set.toList xs
        let _ = x.SetWorkMode 2
        for var in xs do
            let _ = x.ReadModbus( ReadVar var)
            () }

    member p.PerformTestConc sensor sensInd scalePt termoPt conc = 
        Logging.info "Выполняется считывание данных для расчёта погрешности прибора %s: %A, %A, %A, %A" p.What sensor sensInd scalePt termoPt
        match p.ReadModbus( ReadVar <| SensorIndex.conc sensInd ) with
        | Err err->  Logging.error "Не удалось считать концентрацию: %s" err
        | Ok conc  ->
            match p.ReadModbus( ReadVar <| SensorIndex.termo sensInd ) with
            | Err err->  Logging.error "Не удалось считать температуру пироприёмника: %s" err
            | Ok temp ->
                 p.setVar (Test (sensInd, scalePt, termoPt), SensorIndex.conc sensInd) (Some conc)
                 p.setVar (Test (sensInd, scalePt, termoPt), SensorIndex.termo sensInd) (Some temp)
                 match p.GetConcError(sensInd, scalePt, termoPt) with
                 | None -> Logging.info "Погрешность не была расчитана" 
                 | Some ve ->
                    (if ve.IsError then Logging.error else Logging.info) "Погрешность: %A" ve
 
    member p.FixProdData prods = 
        let physVars = 
            prods 
            |> List.map  ProdDataPt.physVars 
            |> List.concat
            |> Set.ofList

        for physVar in physVars do
            if notKeepRunning() then () else            
            match p.ReadModbusLog( ReadVar physVar) with
            | Err error->
                Logging.warn  "%s: %s: %s"  p.What physVar.What error
            | Ok readedValue -> 
                let strValue = Decimal.toStr6 readedValue
                Logging.info  "%s : %s -> %s"  p.What physVar.What strValue
                let f = ProdDataPt.physVars  >> List.exists ( (=) physVar )
                for prodPt in List.filter f prods do
                    p.setVar (prodPt,physVar) (Some readedValue)
                    Logging.info 
                        "%s : %s, %s <- %s" 
                        p.What (ProdDataPt.what prodPt) physVar.What strValue 

type Ankat.ViewModel.Party with
    
    member x.DoForEachProduct<'a> (f : Ankat.ViewModel.Product -> Result<'a,string>) = 
        let xs = x.Products |> Seq.filter(fun p -> p.IsChecked)
        if Seq.isEmpty xs then
            Err "приборы не отмечены"
        else
            for p in xs do 
                if isKeepRunning() && p.IsChecked then 
                    match f p with
                    | Err error -> 
                        Logging.error "%s : %s" p.What error
                    | _ -> ()
            Ok ()

    member x.DoForEachProduct (f : Ankat.ViewModel.Product -> string option) = 
        x.DoForEachProduct ( f >> Option.toResult )

    member x.Interrogate() = Option.toResult <| maybeErr {        
        let xs = x.Products |> Seq.filter(fun p -> p.IsChecked)
        if Seq.isEmpty xs then
            return "приборы не отмечены"
        else
            let nfop = MainWindow.HardwareInfo.products
            for p in xs do 
                if isKeepRunning() && p.IsChecked then                         
                    do! p.Interrogate()                    
        }

    member x.WriteModbus(cmd,value) = maybeErr{
        
        do! x.DoForEachProduct (fun p -> p.WriteModbus(SendCommand cmd,value)   ) }

    member x.SetModbusAddrs() = maybeErr{
        do! x.DoForEachProduct (fun p -> p.SetModbusAddr()   ) }

    member x.SetWorkMode mode = maybeErr{
        do! x.DoForEachProduct (fun p -> p.SetWorkMode mode ) }

    member x.WriteKefs(kefs) = maybeErr{
        do! x.DoForEachProduct (fun p -> 
            p.WriteKefs kefs  ) }

    member x.ReadKefs(kefs) = maybeErr{
        do! x.DoForEachProduct (fun p -> 
            p.ReadKefs kefs  ) }

    member x.ComputeAndWriteKefGroup (kefGroup) = 
        x.DoForEachProduct(fun p -> 
            p.ComputeKefGroup kefGroup
            (Correction.coefs kefGroup)
            |> List.map (fun x -> x, None)
            |> p.WriteKefs  )

    member x.FixProdData prods =
        x.DoForEachProduct ( fun p -> 
            p.FixProdData prods 
            Ok ()
            ) 
        |> Result.someErr
   
module Delay = 
    let onStart = Ref.Initializable<_>(sprintf "Delay.start %s:%s" __LINE__ __SOURCE_FILE__ )
    let onStop = Ref.Initializable<_>(sprintf "Delay.stop %s:%s" __LINE__ __SOURCE_FILE__ )
    let onUpdate = Ref.Initializable<_>(sprintf "Delay.stop %s:%s" __LINE__ __SOURCE_FILE__ )

    let mutable private keepRunning = false

    let cancel() = keepRunning <- false

    let perform what gettime interrogate = 
        onStart.Value what gettime
        keepRunning <- true
        let start'time = DateTime.Now
        let result = 
            maybeErr{
                while keepRunning && Thread2.isKeepRunning() && (DateTime.Now - start'time < gettime()) do
                    onUpdate.Value start'time gettime
                    if interrogate then
                        do! party.Interrogate()
                    else
                        Threading.Thread.Sleep 10 }
        keepRunning <- false
        onStop.Value() 
        result

    let sleep what time = 
        perform what (fun() -> time) false 
        |> ignore

module ModalMessage = 
    let onShow = Ref.Initializable<_>(sprintf "ModalMessage.onShow %s:%s" __LINE__ __SOURCE_FILE__ )
    let getIsVivisble = Ref.Initializable<_>(sprintf "ModalMessage.getIsVivisble %s:%s" __LINE__ __SOURCE_FILE__ )
    let onClose = Ref.Initializable<_>(sprintf "ModalMessage.onClose %s:%s" __LINE__ __SOURCE_FILE__ )
    
    let show (level:Logging.Level) (title:string) (text:string) = 
        onShow.Value title level text
        while Thread2.isKeepRunning() && getIsVivisble.Value() do
            Threading.Thread.Sleep 50
        onClose.Value()    

[<AutoOpen>]
module private Helpers1 = 
    
    let none _ = None
    let (<|>) what f = 
        Operation.CreateSingle (what, none) f 
    let (<-|->) (what,time,whatDelay) f = 
        Operation.CreateTimed (what, none) (Delay.create time whatDelay) f
    let (<||>) what xs =  Operation.CreateScenary ( what, none)  xs

    let computeGroup kefGroup = 
        sprintf "Расчёт %A" (Correction.what kefGroup) <|> fun () -> 
            party.ComputeKefGroup kefGroup
            None

    let writeGroup kefGroup = 
        sprintf "Запись к-тов группы %A" (Correction.what kefGroup) <|> fun () -> 
            (Correction.coefs kefGroup)
            |> List.map(fun x -> x, None)
            |> party.WriteKefs 

    let computeAndWriteGroup kefGroup = 
        (Correction.what kefGroup) <||> [   
            "Расчёт" <|> fun () -> 
                party.ComputeKefGroup kefGroup
                None
            "Запись" <|> fun () ->  
                (Correction.coefs kefGroup)
                |> List.map(fun x -> x, None)
                |> party.WriteKefs ]

    
    type Op = Operation

    let switchPneumo clapan = maybeErr{
        let code, title, text = 
            match clapan with
            | Some clapan -> 
                let code = Clapan.code clapan
                let what = Clapan.what clapan
                byte code, "Продувка " + what, "Подайте " + what
            | _ -> 0uy, "Выключить пневмоблок", "Отключите газ"

        if appCfg.Hardware.Pneumoblock.UsePneumoblock then
            do! Hardware.Pneumo.switch code
        else            
            ModalMessage.show Logging.Info  title text 
            if isKeepRunning() then
                match clapan with
                | Some clapan -> Logging.info "газ %s подан вручную" (Clapan.what clapan)
                | _ -> Logging.info "пневмоблок закрыт вручную" }

    let blow minutes pt what = 
        let s = Clapan.what pt
        let title, text = "Продувка " + s, "Подайте " + s

        (what, TimeSpan.FromMinutes (float minutes), BlowDelay pt ) <-|-> fun gettime -> maybeErr{        
            do! switchPneumo <| Some pt
            do! Delay.perform title gettime true }

    let warm t = maybeErr{    
        if appCfg.Hardware.Pneumoblock.UsePneumoblock && Hardware.Pneumo.isOpened()  then
            do! switchPneumo None
        let value = party.GetTermoTemperature t
        Logging.info "Установка температуры %A %M\"C" (TermoPt.what t) value
        if not appCfg.Hardware.Termochamber.UseTermochamber then             
            ModalMessage.show Logging.Info
                "Уставка термокамеры" (sprintf "Установите в термокамере температуру %M\"C" value) 
            if isKeepRunning() then
                Logging.info "температура %s установлена вручную" t.What
        else 
            do! Hardware.Warm.warm value Thread2.isKeepRunning party.Interrogate  }


    let cmdAdjust = function        
        | Sens1, ScaleBeg -> CmdAdjustNull1
        | Sens1, ScaleEnd -> CmdAdjustScale1
        | Sens2, ScaleBeg -> CmdAdjustNull2
        | Sens2, ScaleEnd -> CmdAdjustScale2
        
    let isSens2() = party.getProductType().Sensor2.IsSome
    
    let adjustNull() = 
        
        ("Калибровка нуля шкалы", TimeSpan.FromMinutes 5., AdjustDelay ScaleBeg)  <-|-> fun gettime -> maybeErr{
            let pgsConc = party.GetPgs Gas1
            Logging.info  "Калибровка нуля шкалы, %M"  pgsConc
            do! switchPneumo <| Some Gas1
            do! Delay.perform "Продувка перед калибровка нуля шкалы" gettime true
           
            do! party.WriteModbus( cmdAdjust (Sens1,ScaleBeg), pgsConc ) 
            if isSens2() then
                do! party.WriteModbus( cmdAdjust (Sens2,ScaleBeg), pgsConc )             
            do! Delay.perform 
                    "Выдержка после калибровки нуля шкалы"
                    ( fun () -> TimeSpan.FromSeconds 10.) true
            }

    let adjustSens n = 
        let cmd = cmdAdjust (n,ScaleEnd)   
        let clapan = ScaleEnd.Clapan n
        let what1 = sprintf "чувствительности канала %d" n.N
        ("Калибровка " + what1, 
            TimeSpan.FromMinutes 5., AdjustDelay ScaleEnd)  <-|-> fun gettime -> maybeErr{
            let pgs = party.GetPgs clapan
            Logging.info  "%s, %M" n.What pgs
            do! switchPneumo <| Some clapan
            do! Delay.perform ("Продувка перед калибровкой " + what1)  gettime true
            do! party.WriteModbus( cmdAdjust (n,ScaleEnd) , pgs ) 
            do! Delay.perform ("Выдержка после калибровки " + what1) (fun () -> TimeSpan.FromSeconds 10.) true
            } 
        
    

    let blowAir() = 
        "Продувка азотом" <||> [   
            blow 5 Gas1 "Продуть азот"
            "Закрыть пневмоблок" <|> fun () -> switchPneumo None
        ]

    let adjust() =
        "Калибровка" <||> [   
            yield adjustNull()
            yield adjustSens Sens1
            if isSens2() then
                yield adjustSens Sens2
            yield blowAir()]
            
    let norming() = 
        ("Нормировка", TimeSpan.FromMinutes 5., BlowDelay Gas1) <-|-> fun gettime -> maybeErr{            
            do! switchPneumo <| Some Gas1
            do! Delay.perform "Продуть воздух" gettime true
            do! party.WriteModbus( Sens1.CmdNorm, 100m ) 
            if isSens2() then
                do! party.WriteModbus( Sens2.CmdNorm, 100m )
            do! Delay.perform "Пауза 5 с для реакции прибора" (fun () -> TimeSpan.FromSeconds 5.) false
            do! switchPneumo None }

    let setupTermo temperature =
        let strT = TermoPt.what temperature        
        "Установка " + strT <||> [
            "Уставка термокамеры " + strT  <|> fun () -> warm temperature
            ("Выдержка термокамеры " + strT, 
                TimeSpan.FromHours 2., WarmDelay temperature) <-|-> fun gettime -> maybeErr{    
                do! switchPneumo None   
                do! Delay.perform ( "Выдержка термокамеры " + strT ) gettime true } ]

    let stopTermo() =
        "Остановка термокамеры" <|> fun ()  ->
            Hardware.Termo.stop isKeepRunning
                |> Result.someErr

    
    let fixProdData prods =
        let physVars = 
            prods 
            |> List.collect  ProdDataPt.physVars
            |> Set.ofList

        let strPhysVars = Seq.toStr ", " PhysVar.what physVars
        let strProds = Seq.toStr ", " ProdDataPt.what prods

        sprintf "Снятие %s <- %s" strProds strPhysVars <|> fun () ->
            party.FixProdData prods

    let blowAndRead<'a> (clapan_points : (Clapan * ('a list)) list ) (f : 'a -> ProdDataPt) =
        [   for clapan,points in clapan_points do
                yield Clapan.what clapan <||> [   
                    blow 5 clapan "Продувка"
                    points  
                        |> List.map f  
                        |> fixProdData    ] ]

    let fixSensConcError sensInd temp = 
        (SensorIndex.what sensInd) <||> 
            [   for scalePt in ScalePt.valuesList do 
                    yield blow 5 (scalePt.Clapan sensInd) ( "Продувка " + (scalePt.Clapan sensInd).What )
                    yield fixProdData [ Test(sensInd, scalePt, temp) ] 
            ]

    let fixConcError() = 
        "Снятие погрешности"  <||>
            [   for temp in [ TermoNorm; TermoHigh; TermoLow;   ] do
                    yield temp.What <||>
                        [   yield setupTermo temp
                            if temp = TermoNorm then
                                yield adjust()
                            yield fixSensConcError Sens1 temp
                            if isSens2() then
                                yield fixSensConcError Sens2 temp                
                            yield blowAir()
                        ]
                yield setupTermo TermoNorm
            ]

        

    let lin() = 
        let points = [   
            yield Gas1, [   yield Sens1, Lin1; 
                            if isSens2() then 
                                yield Sens2, Lin1] 
            yield S1Gas2, [Sens1, Lin2] 
            if party.getProductType().Sensor.IsCH |> not then
                yield S1Gas2CO2, [Sens1, Lin3] 

            yield S1Gas3, [Sens1, Lin4]
             
            if isSens2() then 
                yield S2Gas2, [Sens2, Lin2] 
                yield S2Gas3, [Sens2, Lin4] ]

        "Линеаризация" <||> [
            yield! blowAndRead points LinPt
            yield blowAir()
            yield computeAndWriteGroup <| CorLin Sens1
            if isSens2() then
                yield computeAndWriteGroup <| CorLin Sens2  ]

    let termo() =
        let points t = [   
            yield Gas1, [   yield TermoScalePt(Sens1, ScaleBeg, t) 
                            if isSens2() then 
                                yield TermoScalePt(Sens2, ScaleBeg,t) 
                            yield TermoPressPt t
                        ]
                                 
            yield S1Gas3, [ TermoScalePt(Sens1, ScaleEnd,t)] 
            if isSens2() then 
                yield S2Gas3, [TermoScalePt(Sens2, ScaleEnd,t)] ] 

        "Термокомпенсация"  <||> [
                    
            for t in [TermoNorm; TermoLow; TermoHigh; ] do
                yield t.What <||> [
                    yield setupTermo t
                    yield! blowAndRead (points t) id 
                    yield blowAir() 
                 ]            
            yield computeAndWriteGroup <| CorTermoScale (Sens1,ScaleBeg)
            yield computeAndWriteGroup <| CorTermoScale (Sens1,ScaleEnd)
            if isSens2() then
                yield computeAndWriteGroup <| CorTermoScale (Sens2,ScaleBeg)
                yield computeAndWriteGroup <| CorTermoScale (Sens2,ScaleEnd)
            yield computeAndWriteGroup <| CorTermoPress
               ]    

    let initCoefs() =         
        "Установка к-тов исполнения" <|> fun () -> 
            party.DoForEachProduct (fun p -> 
                p.WriteKefsInitValues() ) 
            |> Result.someErr

    let workAllCheckedProducts workName work = 
        workName <|> fun _ ->
            for p in party.Products do
                if p.IsChecked && (isKeepRunning()) then 
                    match work p with 
                    | Err err -> Logging.error "прибор %d: %s" p.SerialNumber err
                    | Ok () -> Logging.info "прибор %d: успешно" p.SerialNumber
            None

    let logProductsVars() = 
        let vars = [ CoutCh0; TppCh0; Uw_Ch0; Ur_Ch0; WORK0; REF0; 
            Var1Ch0; Var2Ch0; Var3Ch0; CoutCh1; TppCh1; Uw_Ch1; Ur_Ch1; WORK1;
            REF1; Var1Ch1; Var2Ch1; Var3Ch1 ]
        Logging.info "Считывание параметров приборов партии"
        for p in party.Products do
            if p.IsChecked && (isKeepRunning()) then 
                for var in vars do
                    if isKeepRunning() then 
                        match p.ReadModbus(ReadVar var) with 
                        | Ok value ->
                            Logging.info "прибор %d: рег.%d=%M, %s %s" p.SerialNumber var.Code value var.What var.Dscr
                        | Err err ->
                            Logging.info "прибор %d: %s: рег.%d %s %s" p.SerialNumber err var.Code var.What var.Dscr
    
    let workLogProductsVars() = "Считывание текущих значений параметров приборов" <|> fun () ->
        logProductsVars()
        None

let production() = 
   
    (if isSens2() then "2K" else "1K") <||> [

        workLogProductsVars()
        workAllCheckedProducts "Установка К49=273" ( fun p -> p.WriteKef(KdFt, Some 273m) )
        setupTermo TermoNorm
        workAllCheckedProducts "Корректировка температуры mcu" ( fun p ->  
            result {
                let! k49 = p.ReadModbus(ReadKef KdFt)
                let! t = Hardware.Termo.read1 isKeepRunning
                let! tmcu = p.ReadModbus(ReadVar Tmcu)
                do! p.WriteModbus(WriteKef KFt, k49 + t - tmcu)                 
            }
        )     
        "Установка режима работы" <|> fun _ ->
            party.SetWorkMode 2
        workLogProductsVars()
        initCoefs()
        workLogProductsVars()
        norming()
        workLogProductsVars()
        adjust()
        workLogProductsVars()
        lin()
        workLogProductsVars()
        termo()
        workLogProductsVars()
        fixConcError() 
        stopTermo()]


module Works =
    let all() = Op.MapReduce Some (production()) 

    let blow() = 
        all() |> List.choose ( function 
            | (Op.Timed (_, ({DelayContext = BlowDelay gas} as delay),_) as op) -> 
                Some (op,delay,gas)
            | _ -> None)

    let warm = 
        all() |> List.choose ( function 
            | (Op.Timed (_, ({DelayContext = WarmDelay t} as delay),_) as op) -> 
                Some (op,delay,t)
            | _ -> None)



[<AutoOpen>]
module private Helpers3 =
    let ( -->> ) s f =
        s <|> f
        |> Thread2.run DontNeedStopHardware

    
let runInterrogate() = "Опрос" -->> fun () -> maybeErr{ 
    while Thread2.isKeepRunning() do
        do! party.Interrogate() }


let setAddr() = "Установка адреса 1" -->> party.SetModbusAddrs

let setWorkMode mode = 
    sprintf "Установка режима %d" mode  -->> fun _ ->
        party.SetWorkMode mode

let sendCommand (cmd,value as x) = 
    sprintf "%s <- %M" (Command.what cmd) value -->> fun () -> 
        party.WriteModbus x


module Pneumoblock =
    
    let switch clapan = 
        
        Clapan.what clapan -->> fun () -> 
            Hardware.Pneumo.switch (Clapan.code clapan)
            |> Result.someErr
    let close() = 
        "Выкл." -->> fun () ->
            Hardware.Pneumo.switch 0uy |> Result.someErr

module Kefs = 
    
    let private run s f = 
        s -->> fun () ->
            let x = appCfg.View
            let kefs = 
                Set.intersect 
                    (IntRanges.parseSet x.SelectedCoefs)
                    (IntRanges.parseSet x.VisibleCoefs)
                |> Set.map Coef.tryGetByOrder  
                |> Set.toList
                |> List.choose id
                
            if kefs.IsEmpty then Some "не выбрано ни одного коэффициента" else f kefs

    let write() = run "Запись к-тов" ( List.map(fun x -> x, None) >> party.WriteKefs  )
    let read() = run "Считывание к-тов"  party.ReadKefs

module TermoChamber =
    let private (-->>) s f = 
        s -->> fun () ->
            f () |> Result.someErr

    let start() = "Старт" -->> fun() -> 
        Hardware.Termo.start isKeepRunning
    let stop() = "Стоп" -->> fun() -> 
        Hardware.Termo.stop isKeepRunning
    let setSetpoint value = "Уставка" -->> fun () -> 
        Hardware.Termo.setSetpoint isKeepRunning value
    let read () = "Замер" -->> fun () -> 
        let r = Hardware.Termo.read isKeepRunning
        Logging.write (Logging.resultToLevel r) "%A" r
        Result.map (fun _ -> () ) r