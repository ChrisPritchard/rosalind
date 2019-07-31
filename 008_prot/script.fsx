
open System
open System.IO
#load "../codons.fs"

let dna = File.ReadAllText "./input.txt"

dna 
|> Seq.chunkBySize 3 
|> Seq.fold (fun (acc, stopped) s -> 
    if stopped then (acc, true) 
    else 
        let v = Codons.table.[String.Concat s]
        if v = "Stop" then (acc, true)
        else acc + v, false) 
    ("", false)
|> fst 
|> printfn "result: %s"