
open System.IO
#load "../fasta.fs"

let s = File.ReadAllText "./input.txt"
let fasta = Fasta.parse s

let target = snd fasta.[0]
let others = fasta |> List.skip 1 |> List.map snd |> List.toArray

let result = 
    [1..target.Length] 
    |> Seq.collect (fun len -> 
        [0..target.Length - len] 
        |> Seq.map (fun start -> target.[start..start+len-1]))
    |> Seq.sortByDescending (fun s -> s.Length)
    |> Seq.find (fun s -> others |> Array.forall (fun other -> other.Contains s))

File.WriteAllText ("output.txt", result)

printfn "Result written to output.txt"