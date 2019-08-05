
#load "../fasta.fs"
#load "../codons.fs"

let input = System.IO.File.ReadAllText "./input.txt"
let fasta = Fasta.parse input

let (_, dna) = fasta.[0]
let introns = fasta |> List.skip 1 |> List.map snd

let exons = (dna, introns) ||> Seq.fold (fun dna intron -> dna.Replace (intron, ""))
let rna = exons.Replace ("T", "U")

let result = 
    rna.ToCharArray () 
    |> Array.chunkBySize 3 
    |> Seq.map (fun sa -> System.String sa)
    |> Seq.map (fun s -> Codons.table.[s])
    |> String.concat ""
    |> fun s -> if s.Contains "Stop" then s.[0..s.IndexOf("Stop") - 1] else s

System.IO.File.WriteAllText ("./output.txt", result)
printfn "Result written to output.txt"