﻿namespace Ankat

open System
open Pneumo

type PressPt =
    | PressNorm
    | PressHigh
    
    member x.What = 
        match x with
        | PressNorm -> "740"
        | PressHigh -> "800"
    

    static member what (x:PressPt) = x.What
    static member valuesList = [ PressNorm; PressHigh ] 

    
type TermoPt =
    | TermoNorm
    | TermoLow    
    | TermoHigh
    
    static member what = function
        | TermoLow -> "T-"
        | TermoNorm -> "НКУ"
        | TermoHigh -> "T+"
        
    static member dscr = function
        | TermoLow -> "Пониженная температура"
        | TermoNorm -> "Нормальная температура"
        | TermoHigh -> "Повышенная температура"
        

    static member valuesList = [TermoLow; TermoNorm;  TermoHigh]
    static member defaultTermoTemperature = function
        | TermoLow -> -60m
        | TermoNorm -> 20m
        | TermoHigh -> 80m
        

    member x.Dscr = TermoPt.dscr x
    member x.What = TermoPt.what x
    
// индекс датчика измерения концентрации
type SensorIndex = 
    | Sens1
    | Sens2

// граница шкалы концентрации
type ScaleEdgePt = 
    | ScaleBeg
    | ScaleEnd

    static member valuesList = [ ScaleBeg; ScaleEnd ] 
    
    member x.What = ScaleEdgePt.what x
    
    static member what = function
        | ScaleBeg -> "ПГС1"
        | ScaleEnd -> "ПГС3"

    static member clapan = function
        | _, ScaleBeg -> Gas1
        | Sens1, ScaleEnd -> S1Gas3
        | Sens2, ScaleEnd -> S2Gas3

    member x.Clapan n = ScaleEdgePt.clapan (n,x)

// точка шкалы концентрации
type ScalePt = 
    | ScaleEdge of ScaleEdgePt
    | ScaleMid
    member x.What = ScalePt.what x
    
    static member Beg = ScaleEdge ScaleBeg
    static member End = ScaleEdge ScaleEnd

    static member what = function
        | ScaleEdge x -> x.What
        | ScaleMid -> "ПГС2"

    static member valuesList = 
        [   ScaleEdge ScaleBeg
            ScaleMid
            ScaleEdge ScaleEnd  ] 

    static member clapan = function
        | n, ScaleEdge pt -> ScaleEdgePt.clapan (n,pt)
        | Sens1, ScaleMid -> S1Gas2
        | Sens2, ScaleMid -> S2Gas2

    member x.Clapan n = ScalePt.clapan (n,x)

type PhysVar =
    | CCh0 
    | CCh1 
    | CCh2 
    | PkPa 
    | Pmm 
    | Tmcu 
    | Vbat 
    | Vref 
    | Vmcu 
    | VdatP 
    | CoutCh0 
    | TppCh0 
    | ILOn0 
    | ILOff0 
    | Uw_Ch0 
    | Ur_Ch0 
    | WORK0 
    | REF0 
    | Var1Ch0 
    | Var2Ch0 
    | Var3Ch0 
    | FppCh0 
    | CoutCh1 
    | TppCh1 
    | ILOn1 
    | ILOff1 
    | Uw_Ch1 
    | Ur_Ch1 
    | WORK1 
    | REF1 
    | Var1Ch1 
    | Var2Ch1 
    | Var3Ch1 
    | FppCh1 

    static member context = function
        
        | CCh0 ->      0, "Концентрация - канал 1 (электрохимия 1)"
        | CCh1 ->      2, "Концентрация - канал 2 (электрохимия 2/оптика 1)"
        | CCh2 ->      4, "Концентрация - канал 3 (оптика 1/оптика 2)"
        | PkPa ->      6, "Давление, кПа"
        | Pmm ->       8, "Давление, мм. рт. ст"
        | Tmcu ->      10, "Температура микроконтроллера, град.С"
        | Vbat ->      12, "Напряжение аккумуляторной батареи, В"
        | Vref ->      14, "Опорное напряжение для электрохимии, В"
        | Vmcu ->      16, "Напряжение питания микроконтроллера, В"
        | VdatP ->     18, "Напряжение на выходе датчика давления, В"
        | CoutCh0 ->   640, "Концентрация - первый канал оптики"
        | TppCh0 ->    642, "Температура пироприемника - первый канал оптики"
        | ILOn0 ->     644, "Лампа ВКЛ - первый канал оптики"
        | ILOff0 ->    646, "Лампа ВЫКЛ - первый канал оптики"
        | Uw_Ch0 ->    648, "Значение исходного сигнала в рабочем канале (АЦП) - первый канал оптики"
        | Ur_Ch0 ->    650, "Значение исходного сигнала в опорном канале (АЦП) - первый канал оптики"
        | WORK0 ->     652, "Значение нормализованного сигнала в рабочем канале (АЦП) - первый канал оптики"
        | REF0 ->      654, "Значение нормализованного сигнала в опроном канале (АЦП) - первый канал оптики"
        | Var1Ch0 ->   656, "Значение дифференциального сигнала - первый канал оптики"
        | Var2Ch0 ->   658, "Значение дифференциального сигнала с поправкой по нулю от температуры - первый канал оптики"
        | Var3Ch0 ->   660, "Значение дифференциального сигнала с поправкой по чувствительности от температуры - первый канал оптики"
        | FppCh0 ->    662, "Частота преобразования АЦП - первый канал оптики"
        | CoutCh1 ->   672, "Концентрация - второй канал оптики"
        | TppCh1 ->    674, "Температура пироприемника - второй канал оптики"
        | ILOn1 ->     676, "Лампа ВКЛ - второй канал оптики"
        | ILOff1 ->    678, "Лампа ВЫКЛ - второй канал оптики"
        | Uw_Ch1 ->    680, "Значение исходного сигнала в рабочем канале (АЦП) - второй канал оптики"
        | Ur_Ch1 ->    682, "Значение исходного сигнала в опорном канале (АЦП) - второй канал оптики"
        | WORK1 ->     684, "Значение нормализованного сигнала в рабочем канале (АЦП) - второй канал оптики"
        | REF1 ->      686, "Значение нормализованного сигнала в опроном канале (АЦП) - второй канал оптики"
        | Var1Ch1 ->   688, "Значение дифференциального сигнала - второй канал оптики"
        | Var2Ch1 ->   690, "Значение дифференциального сигнала с поправкой по нулю от температуры - второй канал оптики"
        | Var3Ch1 ->   692, "Значение дифференциального сигнала с поправкой по чувствительности от температуры - второй канал оптики"
        | FppCh1 ->    694, "Частота преобразования АЦП - второй канал оптики"

    static member code = PhysVar.context >> fst
    static member what (x:PhysVar) = sprintf "%A" x
    static member dscr = PhysVar.context >> snd 
    member x.Dscr = PhysVar.dscr x
    member x.What = PhysVar.what x


module private PhysVarHelp = 
    let valuesList = 
        FSharpType.valuesListOf<PhysVar>

type PhysVar with 
    static member valuesList = PhysVarHelp.valuesList

type Id = string

type Command =
    | CmdNorm1
    | CmdAdjustNull1
    | CmdAdjustScale1
    | CmdSetComponent1
    | CmdNorm2
    | CmdAdjustNull2
    | CmdAdjustScale2
    | CmdSetComponent2
    | CmdCorrectT
    | CmdSetAddr
    static member context = function
        | CmdNorm1         ->  8, "Нормировать каналы 1 ИКД"
        | CmdAdjustNull1   ->  1, "Коррекция нуля 1"
        | CmdAdjustScale1  ->  2, "Коррекция конца шкалы 1"
        | CmdSetComponent1 ->  16, "Установить тип газа 1"
        | CmdNorm2         ->  9, "Нормировать каналы 2 ИКД"
        | CmdAdjustNull2   ->  4, "Коррекция нуля 2"
        | CmdAdjustScale2  ->  5, "Коррекция конца шкалы 2"
        | CmdSetComponent2 ->  17, "Установить тип газа 2"
        | CmdCorrectT      ->  20, "Коррекция смещения датчика температуры"
        | CmdSetAddr       ->  7, "Установка адреса MODBUS"

    static member what = Command.context >> snd
    static member code = Command.context >> fst

    member x.What = Command.what x
    member x.Code = Command.code x
    
    static member valuesList = 
        [   CmdNorm1
            CmdAdjustNull1
            CmdAdjustScale1
            CmdSetComponent1
            CmdNorm2
            CmdAdjustNull2
            CmdAdjustScale2
            CmdSetComponent2
            CmdCorrectT
            CmdSetAddr ]



// индекс датчика измерения концентрации
type SensorIndex with

    member x.Conc = SensorIndex.conc x
    member x.Termo = SensorIndex.termo x
    //member x.Var1 = SensorIndex.var1 x
    member x.Var2 = SensorIndex.var2 x
    member x.N = SensorIndex.n x
    member x.What = SensorIndex.what x

    member x.SensorOfProdTypeByIndex prodType =
        SensorIndex.sensorOfProdTypeByIndex prodType x

    member x.CmdNorm = SensorIndex.cmdNorm x

    static member conc = function
        | Sens1 -> CoutCh0
        | Sens2 -> CoutCh1

    static member termo = function
        | Sens1 -> TppCh0
        | Sens2 -> TppCh1

    //static member var1 = function
    //    | Sens1 -> Var1Ch0
    //    | Sens2 -> Var1Ch1

    static member var2 = function
        | Sens1 -> Var2Ch0
        | Sens2 -> Var2Ch1

    static member n = function
        | Sens1 -> 1
        | Sens2 -> 2

    static member prodTypeCoefs = function
        | Sens1 -> Pgs1_1, Pgs3_1, Gas_Type_1
        | Sens2  -> Pgs1_2, Pgs3_2, Gas_Type_2

    static member valuesList = [Sens1; Sens2]

    static member coefsLin = function
        | Sens1 -> [CLin1_0; CLin1_1; CLin1_2; CLin1_3]
        | Sens2 -> [CLin2_0; CLin2_1; CLin2_2; CLin2_3]

    static member sensorOfProdTypeByIndex prodType sensorIndex = 
        match sensorIndex, prodType.Sensor2 with
        | Sens1, _ -> Some prodType.Sensor
        | Sens2, sensor -> sensor

    static member cmdNorm = function
        | Sens1 -> CmdNorm1
        | Sens2 -> CmdNorm2

    static member what = function
        | Sens1 -> "к.1"
        | Sens2 -> "к.2"

// точка линеаризации
type LinPt =
    | Lin1
    | Lin2
    | Lin3
    | Lin4
    static member valuesList = 
        [   Lin1
            Lin2
            Lin3
            Lin4 ]

    member x.Clapan n = LinPt.clapan (n,x)

    static member clapan = function
        | _, Lin1 -> Gas1
        | Sens1, Lin2 -> S1Gas2
        | Sens1, Lin3 -> S1Gas2CO2
        | Sens1, Lin4 -> S1Gas3
        | Sens2, Lin2 -> S2Gas2
        | Sens2, Lin3 -> failwith "ClapanHelp.clapanOflinPt, there is no Lin3 for Sens2"
        | Sens2, Lin4 -> S2Gas3

// точка снятия данных
type ProdDataPt =
    | LinPt of SensorIndex * LinPt
    | TermoScalePt of SensorIndex * ScaleEdgePt * TermoPt
    | TermoPressPt of TermoPt 
    | Test of SensorIndex * ScalePt * TermoPt

    static member physVars = function
        | LinPt (n,_) -> [n.Conc]
        | TermoScalePt (n,_,_) -> [n.Termo; n.Var2]
        | TermoPressPt _ -> [TppCh0;VdatP]
        | Test (n,_,_) -> [n.Termo; n.Conc]

    static member what = function
        | LinPt (n,m) -> sprintf "LIN%d_%d" (valueOrderOf n) (valueOrderOf m )
        | TermoScalePt (n,ScaleBeg,t) -> sprintf "T0%d_%d" (valueOrderOf n) (valueOrderOf t )
        | TermoScalePt (n,ScaleEnd,t) -> sprintf "TK%d_%d" (valueOrderOf n) (valueOrderOf t )
        | TermoPressPt t -> sprintf "PT%d" (valueOrderOf t )
        | Test (sensInd,scalePt, termoPt) -> sprintf "Test%d_%d_%d" (valueOrderOf sensInd) (valueOrderOf scalePt) (valueOrderOf termoPt)
        

[<AutoOpen>]
module private Helper = 
    
    let scalePts = 
        [   ScaleEdge ScaleBeg
            ScaleMid
            ScaleEdge ScaleEnd ]

    let prodDataPts = 
        [   for s in SensorIndex.valuesList do
                for linPt in LinPt.valuesList do
                    yield LinPt(s,linPt)
            
            for s in SensorIndex.valuesList do
                for pgs in ScaleEdgePt.valuesList do
                    for t in TermoPt.valuesList do
                        yield TermoScalePt(s, pgs, t)
            
            for sensInd in SensorIndex.valuesList do
                for scalePt in ScalePt.valuesList do
                    for termoPt in TermoPt.valuesList do
                        yield Test(sensInd, scalePt, termoPt)

            for t in TermoPt.valuesList do
                yield TermoPressPt(t)
        ]

type ProdDataPt with
    static member valuesList = prodDataPts

// вид компенсации показаний
type Correction = 
    | CorLin of SensorIndex
    | CorTermoScale of SensorIndex * ScaleEdgePt
    | CorTermoPress
    
    static member physVars = 
        Correction.prodDataPts 
        >> List.map ProdDataPt.physVars
        >> List.concat
        >> Set.ofList
        >> Set.toList

    member x.Descr = Correction.descr x
    member x.What = Correction.what x

    static member what = function
        | CorLin n -> sprintf "LIN%d" (valueOrderOf n) 
        | CorTermoScale (n,ScaleBeg) -> sprintf "T0%d" (valueOrderOf n) 
        | CorTermoScale (n,ScaleEnd) -> sprintf "TK%d" (valueOrderOf n) 
        | CorTermoPress -> "PT"
        

    static member descr = function
        | CorTermoPress -> "Компенсация влияния темпемпературы на давление"
        | CorLin n -> sprintf "Линеаризация ф-ии преобразования канала %d" n.N
        | CorTermoScale (n,ScaleBeg) -> 
            sprintf "Компенсация влияния темпемпературы на нулевые показания канала %d" n.N
        | CorTermoScale (n,ScaleEnd) -> 
            sprintf "Компенсация влияния темпемпературы на чувствительность канала %d" n.N
        

    static member coefs = function
        | CorLin Sens1 -> 
            [CLin1_0; CLin1_1; CLin1_2; CLin1_3]
        
        | CorLin Sens2 -> 
            [CLin2_0; CLin2_1; CLin2_2; CLin2_3]
        
        | CorTermoScale (Sens1,ScaleBeg) -> 
            [KNull_T1_0; KNull_T1_1; KNull_T1_2]
        
        | CorTermoScale (Sens1,ScaleEnd) -> 
            [KSens_T1_0; KSens_T1_1; KSens_T1_2]
        
        | CorTermoScale (Sens2,ScaleBeg) -> 
            [KNull_T2_0; KNull_T2_1; KNull_T2_2]
        
        | CorTermoScale (Sens2,ScaleEnd) -> 
            [KSens_T2_0; KSens_T2_1; KSens_T2_2]

        | CorTermoPress  ->
            [KNull_TP_0; KNull_TP_1; KNull_TP_2]
      
    static member fromProdDataPt = function
        | LinPt (n,_) -> Some ( CorLin n )
        | TermoScalePt (n,gas,_) -> Some ( CorTermoScale(n,gas) )
        | Test _ -> None
        | TermoPressPt _ -> Some CorTermoPress

    static member prodDataPts = function
        | CorLin n -> List.map ( fun z ->  LinPt (n,z) )  LinPt.valuesList 
        | CorTermoScale (n,gas) -> List.map ( fun z ->  TermoScalePt (n,gas, z) ) TermoPt.valuesList
        | CorTermoPress -> List.map TermoPressPt TermoPt.valuesList
        
        
type GetPgsConcFun = SensorIndex -> ScaleEdgePt -> decimal

[<AutoOpen>]
module private Helper1 = 
    
    let correctionValues = 
        [   for n in SensorIndex.valuesList do
                yield CorLin n
            
            for s in SensorIndex.valuesList do
                for pgs in ScaleEdgePt.valuesList do
                    yield CorTermoScale(s, pgs)  ]


    let (|CorrectionOfProdDataPt|_|) = Correction.fromProdDataPt

module Points = 

    let sens_gas_t = listOf{ 
        let! n = SensorIndex.valuesList
        let! gas = ScalePt.valuesList
        let! t = TermoPt.valuesList
        return n,gas,t }

    let prod = listOf {
        let! prodDataPt = ProdDataPt.valuesList
        let! physVar = ProdDataPt.physVars prodDataPt
        return prodDataPt, physVar }

[<AutoOpen>]
module ProductTypePgsHelp = 

    type ProductType with

        member x.GetPgsConc a  = ProductType.getPgsConc x a
        member x.DefaultPgsConcMap = ProductType.defaultPgsConcMap x 
    
        static member getPgsConc productType (clapan:Clapan)  = 
            let sensor1 = productType.Sensor
            let sc = sensor1.Scale.Value
            let sensor = 
                match productType.Sensor2, clapan with 
                | Some sensor2, (S2Gas2 | S2Gas3) -> sensor2
                | _ -> sensor1

            let k = 
                match clapan, sensor with 
                | Gas1, _ -> 0m
                | S1Gas2, IsCO2Sensor x -> if x then (1m / 3m) else 0.5m
                | S1Gas2CO2, IsCO2Sensor x -> 2m / 3m 
                | S1Gas3, _ -> 1m
                | S2Gas2, _ -> 0.5m
                | S2Gas3, _ -> 1m

            Math.Round( sensor.Scale.Value * k, 2)

        static member defaultPgsConcMap productType = 
            let sensor1 = productType.Sensor
            [   yield Gas1
                yield S1Gas2
                match sensor1 with 
                | IsCO2Sensor true -> 
                    yield S1Gas2CO2
                | _ -> ()
                yield S1Gas3
                match productType.Sensor2 with 
                | Some sensor2 -> 
                    yield S2Gas2
                    yield S2Gas3
                | _ -> () ]
            |> List.map(fun x -> x, productType.GetPgsConc x)
            |> Map.ofList


type Correction with
    static member values = correctionValues
    
    static member coefsTermo n gas =
        CorTermoScale(n, gas)
        |> Correction.coefs
    
type WriteContext =
    | WriteKef of Coef
    | SendCommand of Command
    static member what = function
        | WriteKef kef -> sprintf "запись коеф.%d" kef.Order
        | SendCommand cmd -> sprintf "отправка команды %A"  <| Command.what cmd
    static member code = function
        | WriteKef kef -> Coef.writeCmd kef
        | SendCommand cmd -> Command.code cmd

type ReadContext =
    | ReadKef of Coef
    | ReadVar of PhysVar
    static member what = function
        | ReadKef kef -> sprintf "коеф.%d" kef.Order
        | ReadVar var -> PhysVar.what var

    static member code = function
        | ReadKef kef -> Coef.readReg kef
        | ReadVar var -> PhysVar.code var

type DelayContext = 
    | BlowDelay of Clapan 
    | WarmDelay of TermoPt
    | AdjustDelay of ScaleEdgePt
    static member values = 
        [   yield! List.map BlowDelay Pneumo.Clapan.valuesList
            yield! List.map WarmDelay TermoPt.valuesList
            yield! List.map AdjustDelay ScaleEdgePt.valuesList  ]

    static member what = function
        | BlowDelay n -> sprintf "Продувка %s" n.What
        | WarmDelay t -> sprintf "Прогрев %s" t.What
        | AdjustDelay n -> sprintf "Калибровка %s" n.What 
    member x.What = DelayContext.what x
    

type Product = 
    {   Id : Id
        IsChecked : bool        
        SerialNumber : int
        SerialPortName : string
        VarValue : Map<ProdDataPt * PhysVar, decimal> 
        CoefValue : Map<Coef, decimal>  }

    member x.What = Product.what x
    static member id x = x.Id
    static member productSerial x = x.SerialNumber
    static member createNewId() = String.getUniqueKey 12
    static member what x = sprintf "А%d" x.SerialNumber 

    static member getVar k p =p.VarValue.TryFind k 

    static member setVar k v =  state{                
        let! p = getState 
        let m = 
            match v with
            | None -> Map.remove k
            | Some v -> Map.add k v
               
        do! setState { p with VarValue = m p.VarValue  } }

    static member getKef k p =p.CoefValue.TryFind k 

    static member setKef k v =  state{                
        let! p = getState 
        let m = 
            match v with
            | None -> Map.remove k
            | Some v -> Map.add k v
               
        do! setState { p with CoefValue = m p.CoefValue   } }

    static member setVars varsValues =  state{ 
        for var,value in varsValues do
            do! Product.setVar var (Some value)    }

    static member setKefs kefsVals = state{            
        for kef,value in kefsVals do
            do! Product.setKef kef (Some value)  }

    static member createNew serialNumber = 
        let now = DateTime.Now
        {   Id = Product.createNewId()
            SerialNumber = serialNumber
            IsChecked = true
            VarValue = Map.empty 
            CoefValue = Map.empty 
            SerialPortName = "COM1"}

    static member tryParseSerailMonthYear s =
        let m = Text.RegularExpressions.Regex.Match(s, @"(\d\d)\s*[\./\s]\s*(\d+)")
        if not m.Success then None else
        let y = Int32.Parse m.Groups.[2].Value - 2000
        let mn = Byte.Parse m.Groups.[1].Value
        if y >= 16 && mn > 0uy && mn < 13uy then 
            Some ( mn, byte y )
        else None

    static member formatSerailMonthYear (m:byte, y:byte) =
        let sm = if m<10uy then sprintf "0%d" m else m.ToString()
        sprintf "%s.%d" sm (2000 + int y)

    static member concErrorlimit (sensor:Sensor) sensInd scalePt termoPt pgsConc product =
        let concVar = SensorIndex.conc sensInd
        let test = Test(sensInd, scalePt, termoPt)
        let tempVar = SensorIndex.termo sensInd
        let temp = Product.getVar (test,tempVar) product
        let sensorConcErrorLimit = sensor.ConcErrorlimit pgsConc

        match termoPt with 
        | TermoNorm -> Some sensorConcErrorLimit
        | _ ->
            if Sensor.isCH sensor then     
            
                let conc20 = Product.getVar (Test(sensInd, scalePt, TermoNorm),concVar) product
                match scalePt, conc20 with
                | ScaleEdge ScaleBeg, _ -> Some 5m
                | _, Some conc20 ->
                    conc20 * 0.15m |> abs  |> decimal |> Some
                | _ -> None
            else
                temp |> Option.map(fun temp -> 
                    let dt = temp - 20m     
                    0.5m * abs( sensorConcErrorLimit*dt ) / 10.0m  
                    )

type LoggingRecord = DateTime * Logging.Level * string

type PerformingOperation =
    {   RunStart : DateTime option 
        RunEnd : DateTime option
        LoggingRecords : LoggingRecord list }
    static member createNew() = 
        {   RunStart = None
            RunEnd = None
            LoggingRecords = [] }        

type PerformingJournal = Map<int, PerformingOperation >

module Party =

    type Head = 
        {   Id : Id
            Date : DateTime
            ProductType : ProductType
            Name : string
            ProductsSerials : int list   }
        static member id x = x.Id 

    type Data = {
        Products : Product list
        Pgs : Map<Clapan,decimal>
        Temperature : Map<TermoPt,decimal>
        Journal : PerformingJournal }

    type Content = Head * Data

    let getNewValidAddy addrs = 
        let rec loop n = 
            if addrs |> Seq.exists( (=) n ) then
                if n=127uy then 1uy else loop (n+1uy)
            else n
        loop 1uy
    
    let createNewEmpty() : Content =         
        {   Id = Product.createNewId()
            ProductsSerials = List.map Product.productSerial []
            Date=DateTime.Now 
            Name = ""
            ProductType = ProductType.first }, 
            {   Products = []
                Pgs = ProductType.first.DefaultPgsConcMap
                Temperature = Map.empty
                Journal = Map.empty}

    let getPgsConc (h,d) pt = 
        d.Pgs.TryFind pt
        |> Option.getWithf(fun () -> 
            h.ProductType.GetPgsConc pt )

module Prop = 
    
    let scalePt = function
        | ScaleMid -> "M"
        | ScaleEdge ScaleBeg -> "0"
        | ScaleEdge ScaleEnd -> "E"

    let t = function
        | TermoNorm -> "N"
        | TermoHigh -> "H"
        | TermoLow -> "L"
        
    let concError (n : SensorIndex, scalePt:ScalePt, tempPt: TermoPt) = 
        sprintf "ConcError%d_%d_%d" (valueOrderOf n) (valueOrderOf scalePt) (valueOrderOf tempPt)

    let physVar (x : PhysVar) = 
        x.What

    let prodData = function
        | LinPt (n,m) -> sprintf "LIN%d_%d" (valueOrderOf n) (valueOrderOf m )
        | TermoScalePt (n,ScaleBeg,t) -> sprintf "T0%d_%d" (valueOrderOf n) (valueOrderOf t )
        | TermoScalePt (n,ScaleEnd,t) -> sprintf "TK%d_%d" (valueOrderOf n) (valueOrderOf t )
        | Test (n,scalePt, termoPt) -> sprintf "TEST%d_%d_%d" (valueOrderOf n) (valueOrderOf scalePt) (valueOrderOf termoPt)
        | TermoPressPt t -> sprintf "PT%d" (valueOrderOf t )

    let dataPoint (x, y  : PhysVar) = 
        sprintf "Var_%s_%s" (prodData x) y.What

    let clapan (x : Clapan)= 
        sprintf "Gas%d" (valueOrderOf x)

    let pgs x = 
        sprintf "Pgs%s" (clapan x)

    let delayContext = function
        | BlowDelay n -> sprintf "BlowDelay_%s" (clapan n)
        | WarmDelay temp -> sprintf "WarmDelay_%s" (t temp)
        | AdjustDelay n -> sprintf "AdjustDelay_%A" n
