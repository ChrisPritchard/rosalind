
#load "../fasta.fs"

// let input = """
// >Rosalind_24
// TCAATGCATGCGGGTCTATATGCAT
// """
let input = System.IO.File.ReadAllText "./input.txt"

let (_, dna) = (Fasta.parse input).[0]

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

let result =
    [0..dna.Length]
    |> Seq.collect (fun i -> 
        [3..11] 
        |> Seq.filter (fun l -> l + i < dna.Length)
        |> Seq.map (fun l -> dna.[i..i+l])
        |> Seq.filter (fun n -> n = revc n)
        |> Seq.map (fun n -> sprintf "%i %i" (i + 1) n.Length))
    |> String.concat "\r\n"

System.IO.File.WriteAllText ("./output.txt", result)
printfn "Result written to output.txt"