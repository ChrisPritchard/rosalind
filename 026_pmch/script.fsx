open System

#load "../fasta.fs"

// let input = """
// >Rosalind_23
// AGCUAGUCAU
// """
let input = """
>Rosalind_3028
GUGAUGUGCAUAGCUUCAACUUGUCGUACUCUACAGCCAGUCGCUUUGGACAUAAGCGAA
GAUGAGUCCACA
"""

let dna = snd (Fasta.parse input).[0]
let au, cg = ((0, 0), dna) ||> Seq.fold (fun (au, cg) -> 
    function 'A' -> au + 1, cg | 'C' -> au, cg + 1 | _ -> au, cg)

let fact n = if n = 0 then bigint 1 else List.reduce (*) [bigint 1..bigint n]

let result = fact au * fact cg
printfn "Result: %A" result