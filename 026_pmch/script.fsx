open System

#load "../fasta.fs"

// let input = """
// >Rosalind_23
// AGCUAGUCAU
// """
let input = """
>Rosalind_8725
CCCAGCCAUUUUGCAAAACUGAACACGGGCUUUGUUCGGGCACACUCGGACUUAGAAAAA
AGGUCUUGUUUUGA
"""

let dna = snd (Fasta.parse input).[0]
let adenine = Seq.filter ((=) 'A') dna |> Seq.length
let cytosine = (dna.Length - (adenine * 2)) / 2

let result = adenine * cytosine * 2
printfn "Result: %i" result