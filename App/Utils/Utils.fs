﻿[<AutoOpen>]
module Utils

open System
open System.IO
open System.ComponentModel
open System.Text
open System.Collections.Generic
open System.Collections.ObjectModel
open System.Text.RegularExpressions
open System.Globalization


let flip f a b = f b a

let apply2 f x y = f (x,y)

let revpair (a,b) = (b,a)

let rec exnRoot (exn:System.Exception) = 
    if exn.InnerException=null then exn else exnRoot exn.InnerException



let bit n x = (1uy <<< n) &&& x <> 0uy 

type Dynamic = Dictionary<string,obj>

type ListBuilder() =
    member this.Bind(m, f) = 
        List.collect f m

    member this.Zero(_) = 
        []

    member this.Return(x) = 
        [x]

// make an instance of the workflow                
let listOf = new ListBuilder()

type Result<'T, 'E> = 
    | Ok of 'T
    | Err of 'E

module Result =
    
    let isErr = function
        | Err _ -> true
        | _      -> false

    let isOk = function
        | Ok _ -> true
        | _      -> false

    let map f = function
        | Ok x -> Ok( f x )
        | Err e -> Err e  

    let mapErr f = function
        | Ok x -> Ok x
        | Err e -> Err ( f e  )

    let bind f = function
        | Ok x ->  f x
        | Err e -> Err e

    let bindErr f = function
        | Ok x ->  Ok x
        | Err e -> f e

    let someErr = function
        | Ok _ ->  None
        | Err e -> Some e

    module Unwrap =         

        let ok = function
            | Ok x -> x
            | Err e -> failwithf "unwraping Err %A as Ok" e

        let err = function
            | Ok x -> failwithf "unwraping Ok %A as Err" x
            | Err e -> e

    type Builder() = 
        member x.Bind(v,f) = bind f v    
        member x.Return v = Ok v
        member x.ReturnFrom o = o
        member b.Combine( v, f) = bind f v
        member b.Delay(f ) = f
        member x.Run(f) = bind f (Ok ())

    

    

let result = Result.Builder()



module Option = 

    let getWith x = function
        | None -> x
        | Some x' -> x'

    let getWithf f = function
        | None -> f()
        | Some x -> x

    let map2 f = function
        | Some x, Some y -> Some ( f(x,y) )
        | _ -> None
    let map3 f = function
        | Some x, Some y, Some z -> Some ( f(x,y,z) )
        | _ -> None

    let bind2 f = function
        | Some x, Some y -> f(x,y)
        | _ -> None

    let toResult = function
        | Some x -> Err x
        | _ -> Ok()

let createDirectory x = 
    if not <| Directory.Exists x then
        let x = Directory.CreateDirectory x
        assert x.Exists

let (|EqualsTo|) lhs rhs = lhs=rhs
let (|RefEqualsTo|) lhs rhs = Object.ReferenceEquals(lhs,rhs)
let (|ValueInRange|) (minv, maxv) n  =     
    n>=minv && n<=maxv

let iterate n f = 
    for k=1 to n do f()


module List =
    let zipCut xs ys = 
        let rec loop r xs ys =
            match xs,ys with 
            | [],_         -> r
            | _,[]         -> r
            | xh::xt,yh::yt -> loop ((xh,yh)::r) xt yt
        loop [] xs ys |> List.rev

    let zipCuty ydef xs ys  = 
        let rec loop r xs ys =
            match xs,ys with 
            | [],_         -> r
            | xh :: xt, []         -> loop ((xh, ydef) :: r) xt []
            | xh::xt,yh::yt -> loop ((xh,yh)::r) xt yt
        
        loop [] xs ys |> List.rev

    let rec tryGetWith f = function
        | [] -> None
        | x::xs ->
            match f x with
            | None -> tryGetWith f xs
            | Some x -> Some x

    let maybeHead = function
        | [] -> None
        | x::_ -> Some x

    let (|Rev|) = List.rev


type Double with
    static member toNullable (x:float) =        
        if Double.IsNaN(x) then None else Some x

    member x.Option =        
        Double.toNullable  x
    
    static member fromOption = function
        | None -> Double.NaN
        | Some x -> x

let fun0() = ()

let inline valuesListOf< ^a when ^a : (static member valuesList : 'a list)> =
    ( ^a : (static member valuesList : 'a list) () )

let inline valueOrderOf< ^a when ^a : (static member valuesList : 'a list)
                            and ^a : equality> (value : 'a) =
    valuesListOf<'a>
    |> List.findIndex ((=) value) 