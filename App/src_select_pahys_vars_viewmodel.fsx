﻿#load "Utils/FsharpRuntime.fs"
#load "Utils/State.fs"
#load "Utils/StrUtils.fs"
#load "Utils/PathUtils.fs"
#load "Utils/DateTimeUtils.fs"
#load "Utils/Logging.fs"
#load "Utils/Utils.fs"
#load "Ankat/Coef.fs"
#load "Ankat/ProductType.fs"
#load "Ankat/Ankat.fs"

open System

open Ankat

let createSourcefile path (source : string []) = 
    System.IO.File.WriteAllLines (__SOURCE_DIRECTORY__ + "/" + path, source)



[|  yield """namespace Ankat.ViewModel
open System
open System.ComponentModel
open Ankat

type InterrogateConverter() =
    inherit MyWinForms.Converters.BooleanTypeConverter("Опрашивать", "Не опрашивать")

[<TypeConverter(typeof<ExpandableObjectConverter>)>]
type SelectPhysVars() = 
    let cfg = AppConfig.config.View """
    

    for x in PhysVar.values do
        yield sprintf """
    [<DisplayName("%s")>]
    [<Description("%s")>]
    [<TypeConverter (typeof<InterrogateConverter>) >]
    member x.%A 
        with get() =
            Set.contains %A cfg.VisiblePhysVars 
        and set value =
            cfg.VisiblePhysVars <- 
                (if value then Set.add else Set.remove) %A cfg.VisiblePhysVars            
            """ x.What x.Dscr x x x
    yield """
    override x.ToString() = cfg.VisiblePhysVars |> Seq.toStr ", " PhysVar.what"""
|]
|> createSourcefile "ViewModels/SelectPhysVarsViewModel.fs" 