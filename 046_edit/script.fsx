
#load "../fasta.fs"

let input = """
>Rosalind_39
PLEASANTLY
>Rosalind_11
MEANLY
"""
// let input = System.IO.File.ReadAllText "./input.txt"

let target, source = Fasta.parse input |> List.map snd |> fun list -> list.[0], list.[1]

let result = bigint 0
printfn "Result: %A" result