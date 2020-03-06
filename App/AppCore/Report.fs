module Ankat.Report

let report1 filename (products : Product list) = 
    
    use file = System.IO.File.CreateText(filename)
    
    let productsLine() = 
        file.Write("\t")
        for p in products do
            file.Write(p.SerialNumber)
            file.Write("\t")
        file.Write("\n")

    let fx = 
        [   (fun scalePt ptT -> TermoScalePt(Sens1,scalePt,ptT)), "Настройка"
            (fun scalePt ptT -> Test(Sens1, ScaleEdge(scalePt),ptT)), "Проверка" ]

    productsLine()

    for ff, what in fx do 
        file.Write(what)
        file.Write("\n\n")        

        for ptT in [TermoNorm; TermoLow; TermoHigh] do
            file.Write(TermoPt.dscr ptT)
            file.Write("\n\n")        
            for scalePt in [ScaleBeg; ScaleEnd] do
                file.Write(ScaleEdgePt.what scalePt)
                file.Write("\n\n")  
                for var in [CoutCh0; TppCh0; WORK0; REF0; Var1Ch0; Var3Ch0] do
                    file.Write(PhysVar.what var)
                    file.Write("\t")
                    for p in products do
                        match Product.getVar (ff scalePt ptT, var) p with
                        | Some value -> file.Write(value)
                        | _ -> file.Write("")
                        file.Write("\t")
                    file.Write("\n")
                file.Write("\n")


