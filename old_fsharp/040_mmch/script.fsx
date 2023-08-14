
#load "../fasta.fs"

// let input = """
// >Rosalind_92
// AUGCUUC
// """
let input = """
>Rosalind_0744
AUCUAUGAUCGAUGCCCGGUUGAGUUUCAGUGUAUGAUCGGGGCCGGUAUGUGCGGCGGU
CCAUUAUUAAUGAGGGACGGACGUCCGCAG
"""

let dna = Fasta.parse input |> List.head |> snd
let nucs = dna |> Seq.countBy id |> Map.ofSeq

let rec fact n m = 
    if n = 0 || m = 0 then bigint 1
    else
        bigint n * fact (n - 1) (m - 1)

let result = 
    fact (max nucs.['A'] nucs.['U']) (min nucs.['A'] nucs.['U']) * 
    fact (max nucs.['C'] nucs.['G']) (min nucs.['C'] nucs.['G'])
printfn "Result: %A" result

// surprising they didn't ask for mod 1 mil here.