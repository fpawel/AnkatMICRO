﻿module Ankat.Alchemy  

open System

type private P = Product
type private T = ProductType



let initKefsValues getPgsConc  prodType =
    let chans = [ 
        yield Sens1, prodType.Sensor
        match prodType.Sensor2 with
        | Some ch -> yield Sens2, ch 
        | _ -> () ]  

    [   yield Coef_Pmmhg_0, 740m
        yield Coef_Pmmhg_1, 0m        
        yield YEAR, decimal DateTime.Now.Year
        yield KNull_TP_0, 0m
        yield KNull_TP_1, 1m
        yield KNull_TP_2, 0m
        for n, sensor in chans do
            let pgs0, pgsK, deviceTypeCoef = SensorIndex.prodTypeCoefs n
            yield pgs0, getPgsConc (ScaleEdgePt.clapan (n,ScaleBeg) )
            yield pgsK, getPgsConc (ScaleEdgePt.clapan (n,ScaleEnd) )
            yield deviceTypeCoef, sensor.SensorCode
            yield! List.zip (SensorIndex.coefsLin n) [0m; 1m; 0m; 0m] 
            yield! List.zip (Correction.coefsTermo n ScaleBeg) [0m; 0m; 0m] 
            yield! List.zip (Correction.coefsTermo n ScaleEnd) [1m; 0m; 0m] ]
        
[<AutoOpen>]
module private PivateComputeProduct = 
    
    type C = 
        | V of ProdDataPt * PhysVar
        | K of Coef
    
    let getVarsValues p vars  =         
        let oks, errs =
            vars |> List.map( fun k ->
                match Product.getVar k p with 
                | None ->  Err k
                | Some value -> Ok (k,value) )
            |> List.partition Result.isOk
        if List.isEmpty errs then 
            Ok ( oks |> List.map ( Result.Unwrap.ok >> snd) ) 
        else 
            errs 
            |> List.map ( Result.Unwrap.err  >> V)
            |> Err
    
    let fmtErr<'a> (fmt : 'a -> string) = function
        | [x] -> sprintf "точке %A" (fmt x)
        | xs -> 
            xs |> List.rev |> Seq.toStr ", " fmt     
            |> sprintf "точках %s"

    let getValuesTermo p n gas var  =
        valuesListOf<TermoPt>
        |> List.map( fun t -> TermoScalePt ( n,gas,t) , var  ) 
        |> getVarsValues p

    let fmtCorrErr f = 
        Result.mapErr( function        
            | [V(CorrectionOfProdDataPt cor, var)] -> 
                sprintf "нет значения %s, %s" cor.What var.What
            | xs -> 
                let strCor = 
                    xs 
                    |> List.map( fun (V(CorrectionOfProdDataPt x,_)) -> x.What ) 
                    |> List.head
                xs |> List.rev |> Seq.toStr ", " (fun (V(prodPt, var)) -> sprintf "(%s,%s)" (f prodPt) var.What )     
                |> sprintf "нет значений %s в точках %s" strCor )

    
    let getGaussXY p getPgsConc prodType  = function
        | CorTermoPress ->
            // [ Termo1, ch1.Tpp, Air; Termo1, ch1.Var1, Air ]
            let xs var =
                getVarsValues p (List.map( fun t -> TermoPressPt t, var) valuesListOf<TermoPt>)                
            result {
                let! temps = xs TppCh0
                let! vars = xs VdatP
                return List.zip temps vars }     
            |> fmtCorrErr ( fun (TermoPressPt t) -> t.What)       
        | CorLin n -> 
            let xs1 = 
                match n, prodType.Sensor with
                | Sens1, IsCO2Sensor true -> [Lin1; Lin2; Lin3; Lin4]
                | _ -> [Lin1; Lin2; Lin4]
            let ys = xs1 |> List.map ( fun linPt -> linPt.Clapan n |> getPgsConc )  
            let xs2 = List.map( fun pt -> LinPt (n,pt), n.Conc ) xs1                
            getVarsValues p xs2
            |> Result.map ( fun xs -> List.zip xs ys )
            |> fmtCorrErr ( fun (LinPt (_,lin) ) -> valueOrderOf lin |> string) 
        
        | CorTermoScale ( n, ScaleBeg ) -> 
            let (~%%) = getValuesTermo p n ScaleBeg 
            result {
                let! t = %% n.Termo
                let! var = %% n.Var2
                return List.zip t var }
            |> Result.map
//                ( fun xy ->            
//                    match prodType.Sensor with
//                    | IsCO2Sensor true -> List.map (fun (x,y) ->  x, -y) xy
//                    | _ -> xy )
                ( List.map (fun (x,y) ->  x, -y) )
            |> fmtCorrErr ( fun (TermoScalePt (_,_,t) ) -> t.What)

        | CorTermoScale ( n, ScaleEnd ) as corr -> 
            result {
                let! t = getValuesTermo p n ScaleEnd n.Termo
                let! var = getValuesTermo p n ScaleEnd n.Var2
                let! var0 = getValuesTermo p n ScaleBeg n.Var2
                return List.zip3 t var0 var}
            |> fmtCorrErr ( fun (TermoScalePt (_,_,t) ) -> t.What)
            |> Result.bind( fun xs ->
                let errs =
                    xs |> List.zip valuesListOf<TermoPt>
                    |> List.map(fun (ptT,(_,var0,var)) ->  if var0 = var then Some ptT else None )
                    |> List.filter Option.isSome
                if List.isEmpty errs then 
                    let vk = xs |> List.map( fun (t,var0,var) -> t, var - var0)
                    vk |> List.map(fun (t,x) -> t, snd vk.[1] / x)
                    |> Ok
                else
                    errs 
                    |> List.map Option.get
                    |> fmtErr TermoPt.what 
                    |> sprintf "при расчёте %s деление на ноль в точке %s" corr.What
                    |> Err )

    let doValuesGaussXY group xy =
        let groupCoefs = Correction.coefs group
        let groupCoefsSet = Set.ofList groupCoefs
        let strGroupCoefs = Seq.toStr ", " (Coef.order >> string) groupCoefs

        let x,y = List.toArray xy |> Array.unzip
        let result =  NumericMethod.GaussInterpolation.calculate(x,y) 
        let ff = Seq.toStr ", " Decimal.toStr6
        Logging.info "метод Гаусса"
        Logging.info "X=%s" (ff x)
        Logging.info "Y=%s" (ff y) 
        Logging.info "%s <- %s" strGroupCoefs (ff result)
        Array.toList result         

let compute group getPgsConc prodType = state {
    let! product = getState
    let groupCoefs = Correction.coefs group
    let groupCoefsSet = Set.ofList groupCoefs
    let strGroupCoefs = Seq.toStr ", " (Coef.order >> string) groupCoefs
    Logging.info "%s : расчёт коэффициентов %A, %s" (Product.what product) (Correction.what group) strGroupCoefs
    do!
        initKefsValues getPgsConc prodType
        |> List.filter(fst >> groupCoefsSet.Contains)
        |> Product.setKefs 
    let result = 
        getGaussXY product  getPgsConc prodType group
        |> Result.map (doValuesGaussXY group)
    match result with
    | Err e -> 
        Logging.error "%s : %s" (Product.what product) e
    | Ok result ->
        do! result |> List.zipCuty 0m groupCoefs |> Product.setKefs   }

type ValueError = 
    {   Value : decimal
        Nominal : decimal
        Limit : decimal }
    member x.IsError = abs x.Error >= abs x.Limit 
    member x.Error = x.Value - x.Nominal
    static member error = function 
        | Some (x : ValueError ) -> Decimal.toStr ".###" x.Error
        | _ -> ""

type Product with

    static member concError sensor getPgsConc (sensInd,scalePt,termoPt) product = 
        Product.getVar (Test(sensInd,scalePt,termoPt), sensInd.Conc) product 
        |> Option.map(fun conc ->                 
            let pgs = getPgsConc(scalePt.Clapan sensInd)
            {   Value = conc
                Nominal = pgs
                Limit = Sensor.concErrorlimit sensor pgs  }  ) 

let createNewProduct serialNumber getPgs productType =
    let prodstate = state {
        let! product = getState
        do!
            (SER_NUMBER, decimal serialNumber)
            :: ( initKefsValues getPgs productType )
            |> Product.setKefs  }
    runState prodstate (Product.createNew serialNumber)
    |> snd


let createNewParty() = 
    let h,d = Party.createNewEmpty()
    let getPgsConc = d.Pgs.TryFind >> Option.getWith 0m
    let productType = h.ProductType
    let product = createNewProduct 1 getPgsConc productType
    let products = [ product ]
    { h with ProductsSerials = [product.SerialNumber] }, { d with Products = products }

let createNewParty1( name, productType : ProductType, count) : Party.Content = 
    let products = 
        [1..count] 
        |> List.map( fun n ->  createNewProduct n productType.GetPgsConc productType )
    {   Id = Product.createNewId()
        ProductsSerials = List.map Product.productSerial products
        Date=DateTime.Now 
        Name = name
        ProductType = productType }, 
            {   Products = products
                Pgs = productType.DefaultPgsConcMap
                Temperature =   
                    [   TermoLow,-30m 
                        TermoNorm, 20m
                        TermoHigh, 45m
                    ]
                    |> Map.ofList
                Journal = Map.empty}
