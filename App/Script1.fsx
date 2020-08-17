#load "Utils/FsharpRuntime.fs"
#load "Utils/State.fs"
#load "Utils/Utils.fs"
#load "Utils/StrUtils.fs"
#load "Utils/DateTimeUtils.fs"
#load "Utils/Assembly.fs"
#load "Utils/PathUtils.fs"
#load "Utils/Logging.fs"
#load "Pneumo.fs"
#load "Ankat/Coef.fs"
#load "Ankat/Sensor.fs"
#load "Ankat/Ankat.fs"

open Ankat

for k in Coef.coefs do
    printfn "kef%A kef = %d" k k.Order

for k in Coef.coefs do
    printfn "kef%A : \"%s\"," k k.Description

for v in PhysVar.valuesList do
    printfn "var%s modbus.Var = %d" v.What v.Code

for v in PhysVar.valuesList do
    printfn "var%s: \"%s\"," v.What v.Dscr

let gas = function
    | CO2_2     -> "CO₂"
    | CO2_5     -> "CO₂"
    | CO2_10    -> "CO₂"
    | C3H8      -> "C₃H₈"
    | SumCH     -> "∑CH"
    | CH4       -> "CH₄"

for t in Ankat.ProductType.values do
    let s1 = t.Sensor
    let gas1 = gas s1
    match t.Sensor2 with
    | None -> printfn "prodT1(%d, \"%s\", %M, %b)," t.TypeNumber gas1 s1.Scale.Value (t.TypeNumber < 20)
    | Some _ -> ()

for t in Ankat.ProductType.values do
    let s1 = t.Sensor
    let gas1 = gas s1
    match t.Sensor2 with
    | None -> ()
    | Some s2 ->        
        let gas2 = gas s2
        printfn "prodT2(%d, \"%s\", %M, \"%s\", %M, %b)," t.TypeNumber gas1 s1.Scale.Value gas2 s2.Scale.Value (t.TypeNumber < 20)
