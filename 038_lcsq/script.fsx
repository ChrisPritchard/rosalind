
#load "../fasta.fs"

let input = """
>Rosalind_23
AACCTTGG
>Rosalind_64
ACACTGTGA
"""
// let input = System.IO.File.ReadAllText "./input.txt"

let result = ""

System.IO.File.WriteAllText ("./output.txt", result)
printfn "Result written to output.txt"