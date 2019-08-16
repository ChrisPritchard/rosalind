
#load "../fasta.fs"

// let input = """
// >Rosalind_57
// AUAU
// """
let input = """
>Rosalind_2527
UGAAUUAAUAUUACGUGGCCAAAUUAGAUCCCGGAUUUAAUCAUGUCGAAUAUUCUAUGC
GGCCUAAACCGGGCGCUUGAUCACCGGCGGCCGCACGAUUGAACGCGUUACGAUUCGCGU
GCAAUCGUACGGCAGCGUAGGCCUACGAUAUCUUGCAGCCGAAGAUCUGUAGCCGCGGGC
CCUAUUAAUUGAUAAUUCAACCGGUAGAUGUUAACUAAUAUAUCGCGAUUUAAUAAGCAU
UUACGAUCUGCUAAUAUAGC
"""

let parsed = Fasta.parse input
let rna = snd parsed.[0]

let paired a b = match a, b with | 'A', 'U' | 'U', 'A' | 'C', 'G' | 'G', 'C' -> true | _ -> false
let cache = System.Collections.Generic.Dictionary<int * int, bigint>()

let rec calc low high = 
    match cache.TryGetValue ((low, high)) with
    | true, v -> v
    | _ ->
        let aggregrator index = 
            if not (paired rna.[low] rna.[index]) then bigint 0
            else if index - low = 1 then bigint 1
            else
                let inner = calc (low + 1) (index - 1)
                if index < high then inner * calc (index + 1) high
                else inner
        let result = List.sumBy aggregrator [low + 1..2..high]
        cache.Add((low, high), result)
        result

let result = calc 0 (rna.Length - 1)
printfn "Result mod 1 mil: %A" (result % bigint 1000000)

// Inspired by: https://adijo.github.io/2016/01/13/rosalind-catalan-numbers-and-rna-secondary-structures/