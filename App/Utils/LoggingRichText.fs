module LoggingRichText

open System
open System.Windows.Forms
open System.Drawing
open System.IO

let private appendText (r:RichTextBox) (text,color) = 
    r.SelectionStart <- r.TextLength
    r.SelectionLength <- 0
    r.SelectionColor <- color
    r.AppendText text
    r.SelectionColor <- r.ForeColor

let private appendLine r (dt:DateTime, level, text) = 
    appendText r (sprintf "%A " dt, Color.DarkGreen)
    appendText r (text + "\n", Logging.foreColor level  )

    
let setLogging (r:RichTextBox) logging  = 
    let len = List.length logging
    if len < 2000 then 
        r.Text <- ""
        List.iter (appendLine r) logging
    else
        r.Text <- sprintf "слишком большой текст: %d строк" len
        
        (*
        try
            let filename = Path.Combine(Path.ofExe, "log.txt")
            r.Text <- filename
            use file = new StreamWriter(filename)
            for (dt,lev,s) in logging do                 
                file.WriteLine("{0} {1} {2}", dt, lev, s  )  
            file.Close()
            System.Diagnostics.Process.Start("explorer.exe", filename) |> ignore    
        with _ ->
            ()
        *)

let addRecord r level text = 
    appendLine r (DateTime.Now, level, text  )
    r.ScrollToCaret()