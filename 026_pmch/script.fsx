open System

#load "../fasta.fs"

// let input = """
// >Rosalind_23
// AGCUAGUCAU
// """
let input = """
>Rosalind_1305
AGACCUCGAGACCGUAUAGAGUAUCCGUGAAAUGGAAACGGCGCCGUUCUCCUUGGGCUU
CAGCUCUAAGUAGCUUAC
"""

let dna = snd (Fasta.parse input).[0]
let adenine = Seq.filter ((=) 'A') dna |> Seq.length
let cytosine = (dna.Length - (adenine * 2)) / 2

let fact n = if n = 0 then 1UL else List.reduce (*) [1UL..uint64 n]

let result = fact adenine * fact cytosine
printfn "Result: %i" result