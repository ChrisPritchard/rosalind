
#load "../codons.fs"

let input = "AGCCATGTAGCTAACTCAGGTTACATGGGGATGACCCCGCGACTTGGATTAGAGTCTCTTTTGGAATAAGCCTGAATGATCCGAGTAGCATCTCAG"
//let input = ""

let rna = input |> Seq.map (function 'T' -> "U" | c -> string c) |> Seq.toArray

let indexes = 
    rna 
    |> Array.windowed 3 |> Array.map (String.concat "") 
    |> Array.indexed |> Array.filter (snd >> (=) "AUG") 
    |> Array.map fst

let protein rna =
    rna 
    |> Seq.chunkBySize 3 
    |> Seq.fold (fun (acc, stopped) s -> 
        if stopped then (acc, true) 
        else 
            let v = Codons.table.[String.concat "" s]
            if v = "Stop" then (acc, true)
            else acc + v, false) 
        ("", false)
    |> fst

let rnaSubs = indexes |> Array.map (fun i -> rna.[i..]) 
let result = rnaSubs |> Array.map protein |> String.concat "\r\n"

printfn "%s" result