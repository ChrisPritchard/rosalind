
open System.IO
#load "../fasta.fs"

let s = File.ReadAllText "./input.txt"
let o = File.OpenWrite "./output.txt"
let w = new StreamWriter(o)

let fasta = Fasta.parse s
for (name, dna) in fasta do
    let suffix = dna.[dna.Length-3..]
    fasta 
    |> List.filter (fun (n, d) -> n <> name && d.[0..2] = suffix)
    |> List.iter (fun (other, _) -> w.WriteLine(sprintf "%s %s" name other))

w.Close ()
w.Dispose ()

printfn "Result written to output.txt"