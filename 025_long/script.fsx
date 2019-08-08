open System

#load "../fasta.fs"

let input = """
>Rosalind_56
ATTAGACCTG
>Rosalind_57
CCTGCCGGAA
>Rosalind_58
AGACCTGCCG
>Rosalind_59
GCCGGAATAC
"""
//let input = System.IO.File.ReadAllText "./input.txt"

let dna = Fasta.parse input |> List.map snd

printfn "%A" dna