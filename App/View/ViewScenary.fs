module Ankat.View.Scenary

open System
open System.Windows.Forms
open System.Drawing

open MainWindow
open Ankat.ViewModel.Operations
open Ankat


[<AutoOpen>]
module private Helpers =

    type C = DataGridViewColumn
    type CheckBoxColumn = MyWinForms.GridViewCheckBoxColumn
    type TextColumn = DataGridViewTextBoxColumn
    let party = Ankat.AppContent.party
    let (~%%) x = x :> C
    let popupDialog = MyWinForms.PopupDialog.create
    type Dlg = MyWinForms.PopupDialog.Options

module private Popup =

    let clearLoggigng() =             
        fst <| popupDialog
            { Dlg.def() with 
                Dlg.Text = Some  "Пожалуйста, подтвердите необходимость очистки журнала выполнения сценария." 
                Dlg.ButtonAcceptText = "Очистить" 
                Dlg.Title = "Очистка журнала"
                Width = 300 }
            ( fun () -> Some () )
            ( fun () ->
                party.Journal <- Map.empty 
                treeListViewScenary.RebuildAll true )

    let delayTime() = 
        let d = Ankat.ViewModel.DelaysHelperViewModel ()
        let g = new PropertyGrid(SelectedObject = d, Width = 400,
                                    Font = new Font("Consolas", 12.f),
                                    ToolbarVisible = false, Height = 500,
                                    PropertySort = PropertySort.Alphabetical)
        let popup = new MyWinForms.Popup(g)    
        popup


module private SelectedOperation = 

    let get() =
        let selectedItem = MainWindow.form.PerformThreadSafeAction ( fun () -> treeListViewScenary.SelectedItem)
        if selectedItem = null then None else
        match selectedItem.RowObject with
        | :? Operation as x -> Some x
        | _ -> None

    let showLoggigng() = 
        get()
        |> Option.iter(fun x -> 
            LoggingRichText.setLogging loggingJournal x.RunInfo.LoggingRecords )

    

    
let initialize =
    treeListViewScenary.CanExpandGetter <- fun x -> 
        match x with
        | :? Operation as x -> 
            match x with
            | Scenary _ -> true
            | _ -> false
        | _ -> false

    treeListViewScenary.ChildrenGetter <- fun x ->
        let xs = 
            match x with
            | :? Operation as x -> x.Children 
            | _ -> [] 
        xs :> Collections.IEnumerable
    
    treeListViewScenary.SelectionChanged.Add <| fun _ ->
        SelectedOperation.showLoggigng()

    ScenaryColumn.name.AspectGetter <- fun x -> 
        match x with
        | :? Operation as x -> box x.Name 
        | _ -> null

    ScenaryColumn.status.AspectGetter <- fun x -> 
        match x with
        | :? Operation as x -> box x.RunInfo.Status 
        | _ -> null

    ScenaryColumn.time.AspectGetter <- fun x -> 
        match x with
        | :? Operation as x -> box x.RunInfo.DelayTime
        | _ -> null

    // при изменении сценария изменить treeListViewScenary
    Thread2.scenary.AddChanged <| fun (_,x) -> 
        treeListViewScenary.SetObjects ([x] :> Collections.IEnumerable)
        treeListViewScenary.CheckedObjectsEnumerable <- ([x] :> Collections.IEnumerable)

        LoggingRichText.setLogging loggingJournal x.RunInfo.LoggingRecords
        treeListViewScenary.ExpandAll()

    Thread2.scenary.Set (PartyWorks.production())

    party.OnAddLogging.Add <| fun (operation, level,text) ->
        SelectedOperation.get()
        |> Option.iter( fun op ->             
            let xs = Operation.tree op
            if xs |> List.exists( fun o -> o.FullName = operation) then
                loggingJournal.PerformThreadSafeAction <| fun () -> 
                    LoggingRichText.addRecord loggingJournal level text )

    Thread2.PerfomOperationEvent.Add <| function
        | operation,true ->
            match SelectedOperation.get() with            
            | Some op when op.FullName = operation.FullName -> 
                loggingJournal.PerformThreadSafeAction <| fun () ->
                    loggingJournal.Text <- ""                   
            | _ -> ()
        | _ -> ()

    treeListViewScenary.FormatRow.Add(fun e -> 
        let x = e.Model :?> Operation
        let apply a b c d =
            e.Item.BackColor <- a
            e.Item.ForeColor <- b
            e.Item.SelectedBackColor <- Nullable c
            e.Item.SelectedForeColor <- Nullable d
        if x.RunInfo.WasPerformed then
            apply Color.Bisque Color.Black SystemColors.HighlightText SystemColors.Highlight
        if x.RunInfo.HasErrors then
            apply Color.LightGray Color.Red Color.MidnightBlue Color.Yellow
        if x.RunInfo.IsPerforming then
            apply Color.Aquamarine Color.Black SystemColors.HighlightText SystemColors.Highlight)

    let cellEditStarting (e:BrightIdeasSoftware.CellEditEventArgs) =
        match e.RowObject :?> Operation with
        | Timed _ as x ->
            let mutable rect = e.Control.Bounds
            let offset = 
                match x.RunInfo.Level with
                | 1 -> -30
                | 2 -> -40
                | 3 -> -65
                | n -> -20 * n
            rect.Offset(offset,0)
            rect.Width <- max 100 rect.Width
            e.Control.Bounds <- rect
        | _ -> e.Cancel <- true
    treeListViewScenary.CellEditStarting.Add cellEditStarting

    let сellEditFinishing (e:BrightIdeasSoftware.CellEditEventArgs) =
        match e.RowObject :?> Operation with
        | Timed _ as x ->
            x.RunInfo.DelayTime <- string e.NewValue
            treeListViewScenary.RefreshItem(e.ListViewItem)
        | _ -> ()
    treeListViewScenary.CellEditFinishing.Add сellEditFinishing

    let _ = new Panel( Parent = TabsheetScenary.BottomTab, Dock = DockStyle.Top, Height = 3)
    let b = new Button( Parent = TabsheetScenary.BottomTab, Dock = DockStyle.Top, 
                        Text = "Очистить журнал", Height = 45, FlatStyle = FlatStyle.Flat,
                        TextAlign = ContentAlignment.MiddleLeft)
    b.Click.AddHandler(fun _ _ ->
        Popup.clearLoggigng().Show b )

    let _ = new Panel( Parent = TabsheetScenary.BottomTab, Dock = DockStyle.Top, Height = 3)
    let b = new Button( Parent = TabsheetScenary.BottomTab, Dock = DockStyle.Top, 
                        Text = "Длит. задержек", Height = 45, FlatStyle = FlatStyle.Flat,
                        TextAlign = ContentAlignment.MiddleLeft)
    b.Click.AddHandler(fun _ _ ->
        Popup.delayTime().Show b )

    fun () -> ()