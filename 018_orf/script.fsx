
#load "../codons.fs"

let input = "AGCCATGTAGCTAACTCAGGTTACATGGGGATGACCCCGCGACTTGGATTAGAGTCTCTTTTGGAATAAGCCTGAATGATCCGAGTAGCATCTCAG"
//let input = System.IO.File.ReadAllLines "./input.txt" |> Array.tail |> String.concat ""

let revc (dna: string) = 
    dna 
    |> Seq.rev
    |> Seq.map (function
        | 'A' -> 'T'
        | 'C' -> 'G'
        | 'T' -> 'A'
        | 'G' -> 'C'
        | _ -> failwith "invalid")
    |> Seq.toArray |> System.String

let rna (dna: string) = 
    dna |> Seq.map (function 'T' -> 'U' | c -> c) |> Seq.toArray |> System.String

/// taken almost verbatim from 008_prot
let protein (rna: string) =
    let res, finished =
        rna 
        |> Seq.chunkBySize 3 
        //|> Seq.filter (fun a -> Array.length a = 3)
        |> Seq.fold (fun (acc, stopped) s -> 
            if stopped then (acc, true) 
            else 
                let key = System.String s
                match Map.tryFind key Codons.table with
                | Some v -> 
                    if v = "Stop" then (acc, true)
                    else acc + v, false
                | None -> 
                    let error = sprintf "invalid: %s\r\n%s" key rna
                    failwith error)
            ("", false)
    if finished then Some res else None

let proteins (rna: string) =
    let openReadingFrames = 
        rna 
        |> Seq.windowed 3 |> Seq.map (Seq.toArray >> System.String) 
        |> Seq.indexed |> Seq.filter (snd >> (=) "AUG") 
        |> Seq.map (fst >> fun i -> rna.[i..])
        |> Seq.toArray

    Array.choose protein openReadingFrames

let result = 
    [|rna input; rna (revc input)|] 
    |> Array.collect proteins 
    |> Array.distinct 
    |> String.concat "\r\n"

printfn "%s" result