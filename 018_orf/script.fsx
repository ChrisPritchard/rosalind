
#load "../codons.fs"

//let input = "AGCCATGTAGCTAACTCAGGTTACATGGGGATGACCCCGCGACTTGGATTAGAGTCTCTTTTGGAATAAGCCTGAATGATCCGAGTAGCATCTCAG"
let input = System.IO.File.ReadAllLines "./input.txt" |> Array.tail |> String.concat ""

let revc dna = 
    dna 
    |> Seq.rev
    |> Seq.map (function
        | 'A' -> 'T'
        | 'C' -> 'G'
        | 'T' -> 'A'
        | 'G' -> 'C'
        | _ -> failwith "invalid")

let rna dna = 
    dna |> Seq.map (function 'T' -> "U" | c -> string c) |> Seq.toArray

/// taken almost verbatim from 008_prot
let protein rna =
    let res, finished =
        rna 
        |> Seq.chunkBySize 3 
        |> Seq.filter (fun a -> Array.length a = 3)
        |> Seq.fold (fun (acc, stopped) s -> 
            if stopped then (acc, true) 
            else 
                let key = String.concat "" s
                match Map.tryFind key Codons.table with
                | Some v -> 
                    if v = "Stop" then (acc, true)
                    else acc + v, false
                | None -> failwith ("invalid char " + key))
            ("", false)
    if finished then Some res else None

let openReadingFrames rna =
    let indexes = 
        rna 
        |> Array.windowed 3 |> Array.map (String.concat "") 
        |> Array.indexed |> Array.filter (snd >> (=) "AUG") 
        |> Array.map fst

    indexes |> Array.map (fun i -> rna.[i..]) |> Array.choose protein

let result = 
    [|rna input; rna (revc input)|] 
    |> Array.collect openReadingFrames 
    |> Array.distinct 
    |> String.concat "\r\n"

printfn "%s" result