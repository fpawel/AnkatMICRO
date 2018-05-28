﻿module Ankat.View.TabPages

open System
open System.Windows.Forms
open System.Drawing
open System.Collections.Generic

open MyWinForms.Utils
open WinFormsControlUtils

open MainWindow
open Ankat
open Pneumo
open Ankat.View.Products

type private P = Ankat.ViewModel.Product
type private VE = Ankat.Alchemy.ValueError


module TabsheetVars =

    type Page = 
        | Lin of SensorIndex
        | T of SensorIndex * ScaleEdgePt
        | PTest of SensorIndex 
        | PT 
       

        static member what = function
            | Lin n ->      Correction.what <| CorLin n                
            | T (n,gas) ->  Correction.what <| CorTermoScale (n,gas)                
            | PTest (n) ->     "Проверка " + n.What 
            | PT ->         Correction.what <| CorTermoPress          

        static member descr = function
            | Lin n ->      Correction.descr <| CorLin n                
            | T (n,gas) ->  Correction.descr <| CorTermoScale (n,gas)                
            | PTest (n) -> sprintf "Проерка погрешности %s" n.What
            | PT ->         Correction.descr <| CorTermoPress           
            

    [<AutoOpen>]
    module private Helpers =
        let pages = [
            yield! List.map Lin SensorIndex.valuesList
            yield! listOf{
                let! n = SensorIndex.valuesList
                let! gas = ScaleEdgePt.valuesList
                return T(n,gas) }
            yield PT
            yield PTest Sens1
            yield PTest Sens2 ]
                

        let mutable page = Lin Sens1

        let addcol dataPropertyName headerText = 
            new DataGridViewTextBoxColumn( DataPropertyName = dataPropertyName, HeaderText = headerText)
            |> gridProducts.Columns.AddColumn

        let termoLeter = function
            | TermoNorm -> ""
            | TermoLow -> "-"
            | TermoHigh -> "+"

        let pressLeter = function
            | PressNorm -> ""
            | PressHigh -> "+"

        let addp () = 
            let p = new Panel(Parent = TabsheetVars.BottomTab, Dock = DockStyle.Top)
            let _ = new Panel(Parent = TabsheetVars.BottomTab, Dock = DockStyle.Top, Height = 10)
            p

    let update () = 
        
        gridProducts.Columns.``remove all columns but`` Columns.main
        match page  with
        | Lin n ->
            for pt in [ yield Lin1; yield Lin2                
                        match n, AppContent.party.getProductType().Sensor with
                        | Sens1, IsCO2Sensor true -> yield Lin3
                        | _ -> ()
                        yield Lin4 ] do
                let linPt = LinPt (n,pt)
                let prop = Prop.dataPoint(linPt,n.Conc)
                addcol prop (LinPt.clapan (n,pt) |> Clapan.what ) 

        | T (n,gas) -> 
            for t in TermoPt.valuesList do
                for var in [n.Var2; n.Termo] do
                    let pt = TermoScalePt(n,gas,t),var
                    addcol (Prop.dataPoint pt) (var.What + termoLeter t)           
        | PTest n  ->
            for termoPt in TermoPt.valuesList do
                for scalePt in ScalePt.valuesList do                
                    let pt = Test(n, scalePt, termoPt), n.Conc
                    addcol (Prop.dataPoint pt) (scalePt.What + " " + termoPt.What)

        | PT ->
            for t in TermoPt.valuesList do
                for var in Correction.physVars CorTermoPress do
                    let pt = TermoPressPt t,var
                    addcol (Prop.dataPoint pt) (var.What + termoLeter t)

        setActivePageTitle <| Page.what page
                
     
    module ProductionPoint =
        let get, set, _ = 
            radioButtons (addp ()) pages Page.what Page.descr <| fun x ->
                page <- x                
                update()

module TabsheetChart = 
    
    let update() =
        setActivePageTitle <| sprintf "График. %s" Chart.physVar.Dscr 
        AppContent.updateChartSeriesList ()
        let m =Chart.axisScalingViewModel
        m.MaxDateTime <- None
        m.MinDateTime <- None
        m.MinY <- None
        m.MaxY <- None
    
module TabsheetErrors =
    
    [<AutoOpen>]
    module private Helpers =
        type Page = 
            {   N  : SensorIndex } 
                
        let mutable page = { N = Sens1 }

        let addp () = 
            let p = new Panel(Parent = TabsheetErrors.BottomTab, Dock = DockStyle.Top)
            let _ = new Panel(Parent = TabsheetErrors.BottomTab, Dock = DockStyle.Top, Height = 10)
            p

        type Fn = P -> VE option
        let colsFns = 
            let x = Dictionary<int, Fn>()
            gridProducts.ColumnRemoved.Add(fun e -> 
                x.Remove(e.Column.GetHashCode()) |> ignore
                )
            x

        let getProductOfRow (g:DataGridView) (e:DataGridViewCellFormattingEventArgs) =
            g.Rows.[e.RowIndex].DataBoundItem :?> P         

        let formatCell (g:DataGridView) (e:DataGridViewCellFormattingEventArgs) ve =  
            let row = g.Rows.[e.RowIndex]
            let col = g.Columns.[e.ColumnIndex]        
            let cell = row.Cells.[e.ColumnIndex]
            let p = getProductOfRow g e
            let decToStr = Decimal.toStr "0.###"
            ve |> Option.map( fun (ve : VE) ->  
            
                let foreColor, backColor = if ve.IsError then Color.Red, Color.LightGray else Color.Navy, Color.Azure 
                let toolTip = 
                    [|  yield "Снятое значение", decToStr ve.Value                     
                        yield "Номинал", decToStr ve.Nominal
                        yield "Абсолютная погрешность", decToStr (ve.Nominal - ve.Value)
                        yield "Предел абсолютной погрешности", decToStr ve.Limit  |]
                    |> Array.map( fun (p,v) -> sprintf "%s : %s" p v)
                    |> fun v -> String.Join("\n", v)
                let value = 100m * ( ve.Nominal - ve.Value ) / ve.Limit                 
                value, foreColor, backColor, toolTip  )
            |> function
            | None -> cell.ToolTipText <- sprintf "%s - нет данных" p.What
            | Some (value, foreColor, backColor, text) ->
                cell.Style.ForeColor <- foreColor
                cell.Style.BackColor <- backColor
                cell.ToolTipText <- sprintf "%s\n%s" p.What text
                e.Value <- Decimal.toStr "0.#" value + "%"
                e.FormattingApplied <- true

    let update () =
        setActivePageTitle (sprintf "Погрешность %s"  page.N.What )
        gridProducts.Columns.``remove all columns but`` Columns.main

        for termoPt in TermoPt.valuesList do
            for scalePt in ScalePt.valuesList do     
                let dataPropName = Prop.concError(page.N, scalePt, termoPt )
                let col = new DataGridViewTextBoxColumn( DataPropertyName = dataPropName, HeaderText = scalePt.What + " " + termoPt.What)
                colsFns.[col.GetHashCode()] <- fun product ->
                    let t = typeof<P>
                    let prop = t.GetProperty dataPropName
                    prop.GetValue(product,null) :?> VE option
                gridProducts.Columns.AddColumn col

    module SensorIndex =
        let get,set, _ = 
            gridProducts.CellFormatting.Add <| fun e ->
                let column = gridProducts.Columns.[e.ColumnIndex]
                if obj.ReferenceEquals( column, Ankat.View.Products.Columns.columnConnection) then
                    let text, fore, back =
                        match e.Value :?> Result<string,string> option with
                        | Some (Ok s) -> s, Color.Black, Color.White
                        | Some (Err s) -> s, Color.Red, Color.LightGray
                        | _ -> "", Color.Black, Color.White
                    e.Value <- text
                    let row = gridProducts.Rows.[e.RowIndex]
                    let cell = row.Cells.[e.ColumnIndex]
                    cell.Style.ForeColor <- fore
                    cell.Style.BackColor <- back
                else
                    let b,f = colsFns.TryGetValue (column.GetHashCode())
                    if b then 
                        let p = getProductOfRow gridProducts e
                        formatCell gridProducts e (f p)

            radioButtons (addp ()) SensorIndex.valuesList SensorIndex.what SensorIndex.what <| fun x -> 
                page <- {page with N = x }
                update()
    
[<AutoOpen>]
module private Helpers1 =
    
    let onSelect = function
        | TabsheetParty -> 
            gridProducts.Columns.``remove all columns but`` Products.Columns.main
            gridProducts.Columns.AddColumns Products.Columns.interrogate 
            gridProducts.Parent <- TabsheetParty.RightTab
        | TabsheetVars ->
            gridProducts.Columns.``remove all columns but`` Products.Columns.main
            gridProducts.Parent <- TabsheetVars.RightTab
            TabsheetVars.update()
        | TabsheetErrors ->
            gridProducts.Columns.``remove all columns but`` Products.Columns.main
            gridProducts.Parent <- TabsheetErrors.RightTab
            TabsheetErrors.SensorIndex.set Sens1
            TabsheetErrors.update()
        
        | TabsheetChart ->
            gridProducts.Parent <- null
            TabsheetChart.update()
        | _ -> ()
        

let getSelected, setSelected,_ =
    gridProducts.Columns.CollectionChanged.Add(fun _ ->
        gridProducts.Columns.SetDisplayIndexByOrder()
        )
    gridProducts.Columns.AddColumns  Products.Columns.main
    
    radioButtons 
        tabButtonsPlaceholder 
        Tabsheet.valuesList
        Tabsheet.title
        Tabsheet.descr
        (fun tabPage ->             
            setActivePageTitle tabPage.Title
            onSelect tabPage
            tabPage.ShowContent() ) 

module TabChart =
    let update() = 
        if getSelected() = TabsheetChart then
            AppContent.updateChartSeriesList ()