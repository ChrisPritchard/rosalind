
open System.IO
#load "../fasta.fs"

let s = File.ReadAllText "./input.txt"
let o = File.OpenWrite "./output.txt"
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
