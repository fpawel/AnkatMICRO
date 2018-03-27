module Thread2

open System
open System.ComponentModel

open Ankat
open Ankat.ViewModel.Operations
open MainWindow

let operations = BindingList<RunOperationInfo>()
let showScenaryReport = Ref.Initializable<_>(sprintf "show'performing'report %s:%s" __LINE__ __SOURCE_FILE__ )
let showPerformingMessage = Ref.Initializable<_>(sprintf "show'performing'message %s:%s" __LINE__ __SOURCE_FILE__ )

[<AutoOpen>]
module private Helpers1 =
    let none _ = None
    let safe = System.Windows.Forms.Control.performThreadSafeAction
    let party = Ankat.AppContent.party
    
    let scenaryKeepRunning = Ref.Observable(false)

let isKeepRunning () = scenaryKeepRunning.Get()
let notKeepRunning() = not (scenaryKeepRunning.Get())
let forceStop() = scenaryKeepRunning.Value <- false

let addKeepRunningHandler f = 
    scenaryKeepRunning.AddChanged f




module private ScenaryConfig =
    open System.IO

    open Nessos.FsPickler

    let fileName = 
        IO.Path.Combine(IO.Path.ofExe, "scenaryConfig.bin" )

    let binarySerializer = FsPickler.CreateBinarySerializer()

    let f<'a> (x:FileMode) (f : FileStream -> 'a) = 
        try
            let file = new FileStream( fileName, x ) 
            let r = f file 
            file.Close()
            Ok r
        with e ->             
            Logging.debug "Ошибка обращения к файлу %s, %A, %A" fileName x e 
            Err e.Message    

    type T = Map<int,Config>

    let dummy msg : T = 
        Logging.debug "%s" msg
        Map.empty

    let open' () =
        if IO.File.Exists fileName |> not then                
            dummy <| sprintf "не найден файл конфигурации сценария %A" fileName 
        else                
            let r = f FileMode.Open <| fun stream ->
                binarySerializer.Deserialize<T>(stream)
            match r  with
            | Err x ->  dummy x
            | Ok x -> x
            
    let save (config : T) =
        f FileMode.Create <| fun stream -> 
            binarySerializer.Serialize( stream, config)
            stream.Close()    


let scenary = 
    let valueRef = Ref.Observable(Operation.CreateSingle("scenary_op", none) none)

    // при изменении сценария 
    valueRef.AddChanged <| fun (_,scenary) ->         
        // изменить treeListViewScenary
        let asIEnumerable = [scenary] :> Collections.IEnumerable
        treeListViewScenary.SetObjects asIEnumerable
        treeListViewScenary.CheckedObjectsEnumerable <- asIEnumerable        
        treeListViewScenary.ExpandAll()
        // показать в журнале сообщения, которые относятся к этому сценарию
        LoggingRichText.setLogging MainWindow.loggingJournal scenary.RunInfo.LoggingRecords
    valueRef

[<AutoOpen>]
module private Helpers2 =
    // операция, выполняемая в текущий момент
    let operationCurrentRunning = 
        let x = Ref.Observable(None)
        Logging.addLogger <| fun l s ->        
            match  x.Value with
            | Some (op:Operation) -> 
                op.RunInfo.AddLogging l s  
                showPerformingMessage.Value l s
            | _ -> ()            
        |> ignore
        x

    open System.Windows.Forms
    
    let showCantExitMessage() = 
        let s = "Нельзя выйти из приложения пока идёт настройка приборов."
        MessageBox.Show(s,"СТМ-30М", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        |> ignore

let private is'running = 
    let x = Ref.Observable(false)
    MainWindow.form.Closing.Add <| fun e ->
        if x.Value then 
            e.Cancel <- true
            forceStop()
            showCantExitMessage()
    x

module IsRunningChangedEvent =

    let addHandler f = 
        is'running.AddChanged <| fun e -> 
            safe form <| fun () -> 
                f e 


type PerformBuilder() =
    let (>>=) p rest = 
        match p with         
        | None when notKeepRunning() -> None
        | None -> rest()
        | x -> x 
    
    member b.Bind(p, rest) = p >>= rest

    member b.Bind(p, rest) = 
        match p with 
        | Ok _ when notKeepRunning() -> None
        | Ok x -> rest x
        | Err x -> Some x         

    member b.Delay(f : unit -> string option) = f

    member x.Run(f) = f()

    member x.While(cond, f) =
        if isKeepRunning() && cond() then f() >>= fun _ -> x.While(cond, f)
        else None

    member x.For(e:seq<_>,f) = 
        let cursor = e.GetEnumerator()
        let body () =  f cursor.Current        
        try
            x.While(cursor.MoveNext, x.Delay(body) )
        with _ ->
            cursor.Dispose()
            reraise()
        
    member b.ReturnFrom (x : string option) = x

    member b.ReturnFrom (x : Result<string,_>) = 
        match x with
        | Err x -> Some x
        | Ok _ -> None

    member b.Return (error:string) = Some error
    member b.Return (x:unit) = None    

    member b.Combine(m, f ) = 
        m >>= f
        
    member b.Zero() = None

    member x.TryWith(p, handler) = 
        try 
            p()
        with  exn -> 
            handler exn 

    member m.TryFinally(f, finalizer) = 
        try 
            f()
        finally 
            finalizer()

let maybeErr = PerformBuilder ()


let sleep50() = Threading.Thread.Sleep 50

let sleep t = 
    let t = TimeSpan.FromMilliseconds( float t )
    let start = DateTime.Now
    while DateTime.Now - start < t && isKeepRunning() do
        System.Threading.Thread.Sleep 50
    None    

let doWork work = 
    if notKeepRunning() then None
    elif party.HasNotOneCheckedProduct() then Some "выполнение прервано, так как не выбрано ни одного прибора"
    else work()

let private perfomOperationEvent = new Event<_>()
[<CLIEvent>]
let PerfomOperationEvent = perfomOperationEvent.Publish

let private stopHardwareWork() =
    let cop s1 s2 f = 
        Option.map
            (   sprintf "Не удалось %s после выполнения сценария, %s" s1 ) 
            (   Logging.warn "Выполняется %s после выполнения сценария" s2
                f() |> Result.someErr ) 


    [   if Hardware.Pneumo.isOpened() then 
            yield cop "закрыть пневмоблок" "закрытие пневмоблока" <| fun () -> 
                  Hardware.Pneumo.switch(0uy)
        match Hardware.Termo.state.Value with
        | Some (Err _ | Ok Hardware.Termo.Stop) 
        | None -> ()
        | _ -> yield cop "остановить термокамеру" "остановка термокамеры" <| fun () -> 
            Hardware.Termo.stop isKeepRunning  ]

type StopHardwareT =
    | NeedStopHardware
    | DontNeedStopHardware


let private beginRun op = 
    let prev'op = operationCurrentRunning.Get()
    operationCurrentRunning.Set (Some op)
    showPerformingMessage.Value Logging.Info ""
    perfomOperationEvent.Trigger(op,true)
    fun () -> 
        operationCurrentRunning.Set prev'op
        perfomOperationEvent.Trigger(op,false)

let private isOperationUncheckedByUser operation = 
    form.PerformThreadSafeAction(fun () -> 
        let mutable found = false 
        let mutable result = false 
        let mutable n = 0
        while n < treeListViewScenary.Items.Count && not found do
            let item = treeListViewScenary.Items.[n]            
            if Object.ReferenceEquals( treeListViewScenary.GetModelObject(item.Index) ,operation) then
                result <- item.StateImageIndex = 0
                found <- true
            n <- n + 1
        result 
        )

let run needStopHardwareOrNot  (x : Operation) =
        
    if scenaryKeepRunning.Value || is'running.Value then
        failwith "already performing"
    operationCurrentRunning.Set (Some x)
    scenaryKeepRunning.Value <- true
    is'running.Set true   
    Logging.info "Начало выполнения сценария %A" x.FullName     
        
    let dostart, dostop = MyWinForms.Utils.timer 10000 AppContent.save
    dostart()
    
    MainWindow.treeListViewScenary.SelectObject x
    MainWindow.loggingJournal.Text <- ""

    Async.Start <| async{    
        let r = Operation.Perform beginRun isKeepRunning isOperationUncheckedByUser x
        let scenaryWasBreakedByUser = not scenaryKeepRunning.Value
        scenaryKeepRunning.Value <- false
            
        let level,message = 
            [   yield r 
                match needStopHardwareOrNot with
                | NeedStopHardware ->
                    yield! stopHardwareWork()  
                | _ -> () ]
            |> fun rs ->
                if rs |> List.exists Option.isSome then 
                    Logging.Error, rs 
                                    |> List.choose id 
                                    |> Seq.toStr "\n" id 
                                    |> sprintf "Выполнение завершилось с ошибкой. %s"
                elif Operation.WasErrorWhenRunning x then
                    Logging.Warn, "при выполнении произошли ошибки"
                elif scenaryWasBreakedByUser then
                    Logging.Warn, "выполнение было прервано"
                else
                    Logging.Info, "Выполнено"
                                    
        safe form dostop
        Comport.Ports.closeOpenedPorts (fun _ _ -> true) 
        Logging.write level "Окончание выполнения сценария %A - %s" x.FullName message
        let title = sprintf "%s %s" x.RunInfo.Status x.FullName
        showScenaryReport.Value title level message 
        operationCurrentRunning.Set None 
        is'running.Set false
        for p in party.Products do
            p.Connection <- None 
        MainWindow.HardwareInfo.products.Hide()
        AppContent.save()   }