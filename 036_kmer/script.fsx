
#load "../fasta.fs"

let input = """
>Rosalind_6431
CTTCGAAAGTTTGGGCCGAGTCTTACAGTCGGTCTTGAAGCAAAGTAACGAACTCCACGG
CCCTGACTACCGAACCAGTTGTGAGTACTCAACTGGGTGAGAGTGCAGTCCCTATTGAGT
TTCCGAGACTCACCGGGATTTTCGATCCAGCCTCAGTCCAGTCTTGTGGCCAACTCACCA
AATGACGTTGGAATATCCCTGTCTAGCTCACGCAGTACTTAGTAAGAGGTCGCTGCAGCG
GGGCAAGGAGATCGGAAAATGTGCTCTATATGCGACTAAAGCTCCTAACTTACACGTAGA
CTTGCCCGTGTTAAAAACTCGGCTCACATGCTGTCTGCGGCTGGCTGTATACAGTATCTA
CCTAATACCCTTCAGTTCGCCGCACAAAAGCTGGGAGTTACCGCGGAAATCACAG
"""
// let input = System.IO.File.ReadAllText "./input.txt"

let dna = Fasta.parse input |> List.head |> snd

let rec allOptions size = 
    ['A'; 'C'; 'G'; 'T'] 
    |> List.collect (fun c -> 
        if size = 1 then [[c]]
        else 
            allOptions (size - 1) 
            |> List.map (fun next -> c::next))

let kMers = allOptions 4 |> List.map (fun kMer -> System.String (kMer |> List.toArray), 0) |> Set.ofList
let inDna = dna |> Seq.windowed 4 |> Seq.map (Array.ofSeq >> System.String) |> Seq.countBy id
let final = Seq.foldBack Set.add inDna kMers
        
let result = final |> Set.toList |> Seq.sortBy fst |> Seq.map (snd >> string) |> String.concat " "

System.IO.File.WriteAllText ("./output.txt", result)
printfn "Result written to output.txt"