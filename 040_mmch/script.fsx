
#load "../fasta.fs"

// let input = """
// >Rosalind_92
// AUGCUUC
// """
let input = """
>Rosalind_7785
AAUGCGGUUAAGUGCGAGUUGGCAUUGCACCCCGCAAAUUAUAGUUCGAGUGACGAACUU
GCUAGCUGUCGCGUACCGCUUCAACGACGGUGGCC
"""

let dna = Fasta.parse input |> List.head |> snd
let nucs = dna |> Seq.countBy id |> Map.ofSeq


let result = nucs.['A'] * nucs.['U'] * nucs.['C'] * nucs.['G']
printfn "Result: %i" result