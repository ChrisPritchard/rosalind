
#load "../fasta.fs"

let input = """
>Rosalind_87
CAGCATGGTATCACAGCAGAG
"""
// let input = System.IO.File.ReadAllText "./input.txt"

let dna = Fasta.parse input |> List.head |> snd



// System.IO.File.WriteAllText ("./output.txt", result)
// printfn "Result written to output.txt"