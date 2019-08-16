
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

// rethink
// target: all possible perfect non-crossing matchings
// meaning, every way all nucs can be matched where none cross
// so for each nuc, all matchings of that nuc that also allow all other nucs to be matched

// so go through nucs, find all nucs following that it can match with
// for each found, test that all nucs inside can match (inner is greater than 0) and all nucs following can be matched (outer > 0)

// so the ultimate result is:
// every total nuc match * every inner nuc match
// which means over a range count all matches, and for each match count all matches for inner range

let rec calc low high = 
    match cache.TryGetValue ((low, high)) with
    | true, v -> v
    | _ ->
        let aggregrator index = 
            if not (paired rna.[low] rna.[index]) then bigint 0
            else if index - low = 1 then bigint 1
            else calc (low + 1) (index - 1)
        let result = List.sumBy aggregrator [low + 1..2..high]
        cache.Add((low, high), result)
        result

let result = calc 0 (rna.Length - 1)
printfn "Result mod 1 mil: %A" (result % bigint 1000000)

// Inspired by: https://adijo.github.io/2016/01/13/rosalind-catalan-numbers-and-rna-secondary-structures/