(*
    Finding the most likely common ancestor:

    In “Counting Point Mutations”, we calculated the minimum number of symbol mismatches between two strings of equal length to model the problem of finding the minimum number of point mutations occurring on the evolutionary path between two homologous strands of DNA. If we instead have several homologous strands that we wish to analyze simultaneously, then the natural problem is to find an average-case strand to represent the most likely common ancestor of the given strands.
*)

open System.IO
#load "./fasta.fs"

let s = File.ReadAllText "./010_input.txt"
let o = File.OpenWrite "./010_output.txt"
let w = new StreamWriter(o)

let fasta = Fasta.parse s
let length = fasta.[0] |> snd |> Seq.length
let profileMatrix = 
    [0..length - 1] |> List.map (fun i ->
        let counts = 
            fasta 
            |> List.map (fun (_, dna) -> dna.[i])
            |> List.countBy id
        counts |> List.maxBy snd |> fst |> w.Write
        counts |> Map.ofList)
w.WriteLine ""
['A';'C';'G';'T'] |> List.iter (fun c -> 
    w.Write (string c + ": ")
    for imap in profileMatrix do
        (Map.tryFind c imap |> Option.defaultValue 0)
        |> fun i -> w.Write (string i + " ")
    w.WriteLine "")

w.Close ()
w.Dispose ()
