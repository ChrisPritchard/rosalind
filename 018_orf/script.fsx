
#load "../codons.fs"

let input = "AGCCATGTAGCTAACTCAGGTTACATGGGGATGACCCCGCGACTTGGATTAGAGTCTCTTTTGGAATAAGCCTGAATGATCCGAGTAGCATCTCAG"
//let input = ""

let reverseComplment = 
    input 
    |> Seq.map (function 'A' -> 'T' | 'T' -> 'A' | 'G' -> 'C' | 'C' -> 'G' | _ -> failwith "invalid") 
    |> Seq.rev |> Seq.toArray
