
#load "../codons.fs"

let input = "AGCCATGTAGCTAACTCAGGTTACATGGGGATGACCCCGCGACTTGGATTAGAGTCTCTTTTGGAATAAGCCTGAATGATCCGAGTAGCATCTCAG"
//let input = ""

let rna = input |> Seq.map (function 'T' -> 'U' | c -> c) |> Seq.toArray

let reverseComplment = 
    input 
    |> Seq.map (function 'A' -> 'T' | 'T' -> 'A' | 'G' -> 'C' | 'C' -> 'G' | _ -> failwith "invalid") 
    |> Seq.rev |> Seq.toArray
