
open System.IO
#load "../fasta.fs"

let sample = File.ReadAllText "./input.txt"
let fasta = Fasta.parse sample

let gcPercent (dna:string) = 
    let byLetter = dna |> Seq.countBy id |> Map.ofSeq
    (float (byLetter.['G'] + byLetter.['C']) / float dna.Length) * 100.

fasta
|> List.map (fun (name, dna) -> name, gcPercent dna)
|> List.maxBy snd
|> fun (name, gc) -> printfn "Result:\r\n%s\r\n%f" name gc