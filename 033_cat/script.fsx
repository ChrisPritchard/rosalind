
#load "../fasta.fs"

let input = """
>Rosalind_57
AUAU
"""
// let input = """
// >Rosalind_2527
// UGAAUUAAUAUUACGUGGCCAAAUUAGAUCCCGGAUUUAAUCAUGUCGAAUAUUCUAUGC
// GGCCUAAACCGGGCGCUUGAUCACCGGCGGCCGCACGAUUGAACGCGUUACGAUUCGCGU
// GCAAUCGUACGGCAGCGUAGGCCUACGAUAUCUUGCAGCCGAAGAUCUGUAGCCGCGGGC
// CCUAUUAAUUGAUAAUUCAACCGGUAGAUGUUAACUAAUAUAUCGCGAUUUAAUAAGCAU
// UUACGAUCUGCUAAUAUAGC
// """

let parsed = Fasta.parse input
let rna = snd parsed.[0]

let paired a b = match a, b with | 'A', 'U' | 'U', 'A' | 'C', 'G' | 'G', 'C' -> true | _ -> false
let cache = System.Collections.Generic.Dictionary<int * int, bigint>()

// a perfect matching is when all nucs in the rna are matched
// its perfect and non crossing when none cross
// to calculate, iterate through the rna:
//      for each nuc, find all matches
//      for each match, add all inner matches and all following matches

let rec calc low high = 
    match cache.TryGetValue ((low, high)) with
    | true, v -> v
    | _ ->
        let mutable result = bigint 0
        for i in [low..high] do 
           let nuc = rna.[i]
           let mutable nucSum = bigint 1
           for j in [i+1..high] do
                if paired nuc rna.[j] then
                   if j - i > 1 then
                       nucSum <- nucSum * calc (i + 1) (j - 1)
           result <- result + nucSum
        cache.Add((low, high), result)
        result

let result = calc 0 (rna.Length - 1)
printfn "Result mod 1 mil: %A" (result % bigint 1000000)

// Inspired by: https://adijo.github.io/2016/01/13/rosalind-catalan-numbers-and-rna-secondary-structures/