open System

#load "../fasta.fs"

// let input = """
// >Rosalind_23
// AGCUAGUCAU
// """
let input = """
>Rosalind_3458
CGUUUACAAUGGUCGGAAAGCGGGCUAUGCAUCAGGUCUGAGCCUCACCACUGCAGACCU
GGUCACUCUCAGGGGC
"""

let dna = snd (Fasta.parse input).[0]
let adenine = Seq.filter ((=) 'A') dna |> Seq.length
let cytosine = (dna.Length - (adenine * 2)) / 2

let result = adenine * (adenine - 1) * cytosine * (cytosine - 1)
printfn "Result: %i" result