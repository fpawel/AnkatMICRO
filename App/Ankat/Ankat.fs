﻿namespace Ankat

open System


type PressurePt =
    | Pnorm
    | Phigh
    member x.What = 
        match x with
        | Pnorm -> "P740"
        | Phigh -> "P800"
    

    static member what (x:PressurePt) = x.What
    static member values = [ Pnorm; Phigh ] 
    static member name (x:PressurePt) = FSharpValue.unionCaseName x


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
        

    static member values = [ TermoNorm; TermoLow;  TermoHigh  ] 
    static member name (x:TermoPt) = FSharpValue.unionCaseName x
    static member defaultTermoTemperature = function
        | TermoLow -> -60m
        | TermoNorm -> 20m
        | TermoHigh -> 80m
        

    member x.Dscr = TermoPt.dscr x
    member x.What = TermoPt.what x

type ScalePt = 
    | ScaleBeg
    | ScaleMid1
    | ScaleMid2
    | ScaleEnd
    member x.What = ScalePt.what x
    static member what = function
        | ScaleBeg -> "ПГС1"
        | ScaleMid1 -> "ПГС2"
        | ScaleMid2 -> "ПГС3"
        | ScaleEnd -> "ПГС4"
    static member whatScale = function
        | ScaleBeg -> "начало шкалы"
        | ScaleMid1 -> "1-ая середина шкалы"
        | ScaleMid2 -> "2-ая середина шкалы"
        | ScaleEnd -> "конец шкалы"
    
    static member defaultBallonConc = function
        | ScaleBeg -> 0m
        | ScaleMid1 -> 50m
        | ScaleMid2 -> 70m
        | ScaleEnd -> 100m
    static member name (x:ScalePt) = FSharpValue.unionCaseName x

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
    static member what (x:PhysVar)= 
        FSharpValue.unionCaseName x
    static member dscr = PhysVar.context >> snd 
    static member values = FSharpType.unionCasesList<PhysVar>
    static member name (x:PhysVar) = FSharpValue.unionCaseName x
    member x.Dscr = PhysVar.dscr x
    member x.What = PhysVar.what x
    
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
    
    static member values = FSharpType.unionCasesList<Command>

// индекс датчика измерения концентрации
type SensorIndex = 
    | Sens1
    | Sens2

    member x.Conc = SensorIndex.conc x
    member x.Termo = SensorIndex.termo x
    member x.Var1 = SensorIndex.var1 x
    member x.N = SensorIndex.n x

    member x.SensorOfProdTypeByIndex prodType =
        SensorIndex.sensorOfProdTypeByIndex prodType x

    member x.ScalePts = SensorIndex.scalePts x

    member x.ScalePts1 = x.ScalePts |> List.map (fun gas-> x,gas)

    static member name (x:SensorIndex) = FSharpValue.unionCaseName x

    static member conc = function
        | Sens1 -> CCh0
        | Sens2 -> CCh1

    static member termo = function
        | Sens1 -> TppCh0
        | Sens2 -> TppCh1

    static member var1 = function
        | Sens1 -> Var1Ch0
        | Sens2 -> Var1Ch1

    static member n = function
        | Sens1 -> 1
        | Sens2 -> 2

    static member prodTypeCoefs = function
        | Sens1 -> Pgs1_1, Pgs3_1, PREDEL_LO_1, PREDEL_HI_1, SHKALA_1, ED_IZMER_1, Gas_Type_1
        | Sens2  -> Pgs1_2, Pgs3_2, PREDEL_LO_2, PREDEL_HI_2, SHKALA_2, ED_IZMER_2, Gas_Type_2

    static member values = [Sens1; Sens2]

    static member coefsLin = function
        | Sens1 -> [CLin1_0; CLin1_1; CLin1_2; CLin1_3]
        | Sens2 -> [CLin2_0; CLin1_2; CLin2_2; CLin2_3]

    static member coefsTermo = function
        | Sens1, ScaleBeg -> [KNull_T1_0; KNull_T1_1; KNull_T1_2]
        | Sens1, ScaleEnd -> [KSens_T1_0; KSens_T1_1; KSens_T1_1]
        | Sens2, ScaleBeg -> [KNull_T2_0; KNull_T2_1; KNull_T2_2]
        | Sens2, ScaleEnd -> [KSens_T2_0; KSens_T2_1; KSens_T2_1]
        | x -> failwithf "ChannelIndex.coefsTermo %A" x

    static member sensorOfProdTypeByIndex prodType sensorIndex = 
        match sensorIndex, prodType.Sensor2 with
        | Sens1, _ -> Some prodType.Sensor
        | Sens2, sensor -> sensor

    static member scalePts = function
        | Sens1 -> [ScaleBeg; ScaleMid1; ScaleMid2; ScaleEnd]
        | Sens2 -> [ScaleBeg; ScaleMid1; ScaleEnd]

type SensorScalePt = SensorIndex * ScalePt 



// канал измерения концентрации
type Channel = 
    {   ChannelSensor : Sensor
        ChannelIndex : SensorIndex }


type GroupCoefs = 
    | LinCoefs of SensorIndex
    | TermoCoefs of SensorScalePt
    | TermoPressureCoefs
    | PressureSensCoefs
    static member ctx = function
        | LinCoefs chan -> 
            [chan.Conc],
                sprintf "LIN%d" chan.N, sprintf "Линеаризация ф-ии преобразов. к.%d" chan.N, 
                    SensorIndex.coefsLin chan,
                        chan.ScalePts, [TermoNorm], [Pnorm]
        
        | TermoCoefs (chan,scalePt) -> 
            let s = 
                match scalePt with
                | ScaleBeg -> "на нулев. показ."
                | ScaleEnd -> "чувст."
                | xx -> failwithf "KefGroup.ctx TermoCoefs(_,%A)" xx
            [chan.Termo; chan.Var1],
                sprintf "T%s%d" scalePt.What chan.N, sprintf "Комп. вл. темп. на %s к. %d" s chan.N, 
                    SensorIndex.coefsTermo (chan,scalePt),
                        [scalePt], TermoPt.values, [Pnorm]

        | PressureSensCoefs ->
            [TppCh0; VdatP],
                "PS", "Комп. влиян. давл. на чувст. по каналам",
                    [Coef_Pmmhg_0; Coef_Pmmhg_1],
                        [ScaleBeg], TermoPt.values, PressurePt.values

        | TermoPressureCoefs ->
            [Pmm; VdatP],
                "PT", "Компенс. влиян. темп. на к. измер. давл.",
                    [KNull_TP_0; KNull_TP_1; KNull_TP_2],
                        [ScaleBeg], TermoPt.values, PressurePt.values   

    member x.What = GroupCoefs.what x
    member x.Dscr = GroupCoefs.dscr x

    member x.Vars = GroupCoefs.vars x
    member x.Gases = GroupCoefs.gases x
    member x.Temps = GroupCoefs.temps x
    member x.Press = GroupCoefs.press x
    member x.Coefs = GroupCoefs.coefs x

    static member vars = GroupCoefs.ctx >> (fun (x,_,_,_,_,_,_) -> x)
    static member what = GroupCoefs.ctx >> (fun (_,x,_,_,_,_,_) -> x)
    static member dscr = GroupCoefs.ctx >> (fun (_,_,x,_,_,_,_) -> x)
    static member coefs = GroupCoefs.ctx >> (fun (_,_,_,x,_,_,_) -> x)
    static member gases = GroupCoefs.ctx >> (fun (_,_,_,_,x,_,_) -> x)
    static member temps = GroupCoefs.ctx >> (fun (_,_,_,_,_,x,_) -> x)
    static member press = GroupCoefs.ctx >> (fun (_,_,_,_,_,_,x) -> x)

    static member values = 
        [   for chan in [Sens1; Sens2] do
                yield LinCoefs chan
            for chan in [Sens1; Sens2] do
                for ptgas in [ScaleBeg; ScaleEnd] do
                    yield TermoCoefs (chan,ptgas)
            yield TermoPressureCoefs
            yield PressureSensCoefs ]

    static member name = function
        | TermoPressureCoefs -> "TermoPressureCoefs"
        | PressureSensCoefs -> "PressureSensCoefs"
        | LinCoefs sensInd -> sprintf "LinCoefs(SensorIndex.%s)" (SensorIndex.name sensInd)
        | TermoCoefs (sensInd,scalePt) -> 
            sprintf "TermoCoefs(SensorIndex.%s, ScalePt.%s)" 
                (SensorIndex.name sensInd)
                (ScalePt.name scalePt)

    static member property = function
        | TermoPressureCoefs -> "TermoPressureCoefs"
        | PressureSensCoefs -> "PressureSensCoefs"
        | LinCoefs sensInd -> sprintf "Lin_%s" (SensorIndex.name sensInd)
        | TermoCoefs (sensInd,scalePt) -> 
            sprintf "Termo_%s_%s" 
                (SensorIndex.name sensInd)
                (ScalePt.name scalePt)

type Feature = 
    | FeatureKefGroup of GroupCoefs
    | Test
    
    static member what = function
        | FeatureKefGroup kg -> kg.Dscr, kg.What
        | Test -> "Проверка","main"

    static member what1 = Feature.what >> fst 
    static member what2 = Feature.what >> snd
    static member name = function
        | Test -> "Test"
        | FeatureKefGroup x -> sprintf "FeatureKefGroup(GroupCoefs.%s)" (GroupCoefs.name x)

    static member property = function
        | Test -> "Test"
        | FeatureKefGroup x -> sprintf "GroupCoefs_%s" (GroupCoefs.property x)

    static member values = 
        [   for kg in GroupCoefs.values do
                yield FeatureKefGroup kg
            yield Test ]

    member x.What1 = Feature.what1 x



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

type Var = Feature * PhysVar * ScalePt * TermoPt * PressurePt

module Vars = 
    let what ( (f,v,s,t,p) as x : Var ) = 
        sprintf "%s.%s.%s.%s.%s" (Feature.what1 f) (PhysVar.what v) (ScalePt.what s) (TermoPt.what t) (PressurePt.what p)

    let property ( (f,v,s,t,p) as x : Var ) = 
        sprintf "%s_%s_%s_%s_%s" (Feature.property f) (PhysVar.name v) (ScalePt.name s) (TermoPt.name t) (PressurePt.what p)

    let sensor_gas_t_vars = 
        [   for sensorIndex in SensorIndex.values do
                for gas in sensorIndex.ScalePts do
                    for t in TermoPt.values do
                        yield sensorIndex, gas,t ]

    let sensor_gas_vars = 
        [   for sensorIndex in SensorIndex.values do
                for gas in sensorIndex.ScalePts do
                    yield sensorIndex, gas ]

    let sensor_gas1_vars = 
        [   for sensorIndex in SensorIndex.values do
                for gas in [ScaleBeg;ScaleEnd] do
                    yield sensorIndex, gas ]

    let vars = 
        [   for kg in GroupCoefs.values do
                for var in kg.Vars do
                    for gas in kg.Gases do
                        for t in kg.Temps do
                            for p in kg.Press do
                                yield (FeatureKefGroup kg), var,gas,t,p
            for sensorIndex in SensorIndex.values do
                for gas in sensorIndex.ScalePts do
                    for t in TermoPt.values do
                        yield Test, sensorIndex.Conc, gas, t, Pnorm  
                        yield Test, sensorIndex.Termo, gas, t, Pnorm  ]
        |> List.sortBy( fun (feat,var,gas,t,p) -> var, feat, t, gas, p)

    let tryGetSensorIndexOfConcVar =
        let xs = SensorIndex.values |> List.map( fun x -> x.Conc, x  ) |> Map.ofList
        xs.TryFind


    let tryGetSensorIndexOfTempVar =
        let xs = SensorIndex.values |> List.map( fun x -> x.Termo, x  ) |> Map.ofList
        xs.TryFind

    let (|SensorIndexOfConcVar|_|) = tryGetSensorIndexOfConcVar
    let (|SensorIndexOfTempVar|_|) = tryGetSensorIndexOfTempVar

    let formatSensorScalePt (s, gas) =
        sprintf "%s/к%d" (ScalePt.what gas) (SensorIndex.n s + 1)

    let sensorScalePoints =
        Sens1.ScalePts1 @ Sens2.ScalePts1

type DelayContext = 
    | BlowDelay of SensorScalePt 
    | WarmDelay of TermoPt
    | AdjustDelay of SensorScalePt
    static member values = 
        [   yield! List.map BlowDelay Vars.sensor_gas_vars
            yield! List.map WarmDelay TermoPt.values
            yield! List.map AdjustDelay Vars.sensor_gas1_vars  ]

    static member what = function
        | BlowDelay (sensInd,gas) -> sprintf "Продувка %s, к.%d" gas.What sensInd.N
        | WarmDelay t -> sprintf "Прогрев %s" t.What
        | AdjustDelay (sensInd,gas) -> sprintf "Калибровка %s, к.%d" gas.What sensInd.N
    member x.What = DelayContext.what x
    member x.Prop = DelayContext.prop x

    static member prop = function
        | BlowDelay (sensInd,gas) -> sprintf "BlowDelay_%s_%d" (ScalePt.name gas) sensInd.N
        | WarmDelay t -> sprintf "WarmDelay_%s" (TermoPt.name t)
        | AdjustDelay (sensInd,gas) -> sprintf "AdjustDelay_%s_%d" (ScalePt.name gas) sensInd.N


    

module Property = 
    let sensorScalePt (sensorIndex,scalePt) = 
        sprintf "Sens%d_%s" (SensorIndex.n sensorIndex) (ScalePt.name scalePt)

    let concError (sensorIndex,scalePt) = 
        sprintf "ConcError_Sens%d_%s" (SensorIndex.n sensorIndex) (ScalePt.name scalePt)
    let termoError (sensorIndex, scalePt,termoPt) = 
        sprintf "TermoError_Sens%d_%s_%s" (SensorIndex.n sensorIndex) (ScalePt.name scalePt) (TermoPt.name termoPt)
    let var var = sprintf "Var_%s" (Vars.property var)

type ProductSerial = 
    {   SerialNumber : uint16
        ProdMonthYear : (byte * byte) option }

type Product = 
    {   Id : Id
        IsChecked : bool        
        ProductSerial : ProductSerial
        Addr : byte
        VarValue : Map<Var, decimal> 
        CoefValue : Map<Coef, decimal>  }

    member x.What = Product.what x
    static member id x = x.Id
    static member productSerial x = x.ProductSerial
    static member createNewId() = String.getUniqueKey 12
    static member what x = sprintf "№%d.#%d" x.ProductSerial.SerialNumber x.Addr 

    static member getVar k p =p.VarValue.TryFind k 

    static member setVar k v =  state{                
        let! p = getState 
        let m = 
            match v with
            | None -> Map.remove k
            | Some v -> Map.add k v
               
        do! setState { p with VarValue = m p.VarValue   } }


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

    static member createNew addy = 
        let now = DateTime.Now
        {   Id = Product.createNewId()
            ProductSerial =
                {   SerialNumber = 0us
                    ProdMonthYear = None }
            Addr = addy
            IsChecked = true
            VarValue = Map.empty 
            CoefValue = Map.empty }

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

    static member termoErrorlimit channel pgs (gas,t) product =
        let concVar = channel.ChannelIndex.Conc
        if not channel.ChannelSensor.Gas.IsCH then         
            let tempVar = channel.ChannelIndex.Termo
            (Product.getVar (Test, concVar, gas,t,Pnorm) product, Product.getVar (Test, tempVar, gas, t,Pnorm) product) 
            |> Option.map2(fun(c,t) -> 
                let dt = t - 20m     
                let maxc = channel.ChannelSensor.ConcErrorlimit pgs
                0.5m * abs( maxc*dt ) / 10.0m )
        else
            match gas with
            | ScaleBeg -> Some 5m
            | _ ->
                Product.getVar (Test,concVar,gas,TermoNorm,Pnorm) product
                |> Option.map(fun conc20 -> conc20 * 0.15m |> abs  |> decimal )

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
            ProductsSerials : ProductSerial list   }
        static member id x = x.Id 
    type Data = {
        Products : Product list
        BallonConc : Map<SensorScalePt,decimal>
        TermoTemperature : Map<TermoPt,decimal>
        PerformingJournal : PerformingJournal }

    type Content = Head * Data

    let getNewValidAddy addrs = 
        let rec loop n = 
            if addrs |> Seq.exists( (=) n ) then
                if n=127uy then 1uy else loop (n+1uy)
            else n
        loop 1uy

    let createNewEmpty() : Content =         
        //let products = [ Product.createNew 1uy 1 A00 ]
        {   Id = Product.createNewId()
            ProductsSerials = List.map Product.productSerial []
            Date=DateTime.Now 
            Name = ""
            ProductType = ProductType.first }, 
            {   Products = []
                BallonConc = Map.empty
                TermoTemperature = Map.empty
                PerformingJournal = Map.empty}

    let ballonConc ( (sensInd : SensorIndex,scalePt) as k) m =
        match Map.tryFind k m with
        | Some x -> x
        | _ -> ScalePt.defaultBallonConc scalePt

