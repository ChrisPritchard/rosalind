
#load "../fasta.fs"

let input = """
>Rosalind_57
AUAU
"""
// let input = """
// >Rosalind_1001
// GAAACUAGCGAUCGUAAUUAUUUAUACGAUCGCGCGUAAACGCGUAUGCCGCGGCUCCGC
// GGAUAUUAGCUCGCCGGGCCUCGAUUCUAGUAAACGACGUUAUUCGCAGUACUGUAGCUA
// CUAGGGUAUACCCUAGCGAUUUAAAAUUGCAUAUAUCGAUGUACCGAAAGCUAUUAUCUA
// GCGAUCCUGCGUACGAUCGCAGUACCGCGCGAUGUCGACGACGUCGAUCCGGGGAUCCCG
// CGGGCGACGUCCGCGCGGCGCUAGAAUUCCGGCGCAGUAAUUUAAGCCCGCUUAAG
// """

let parsed = Fasta.parse input
let rna = snd parsed.[0]

let paired a b = match a, b with | 'A', 'U' | 'U', 'A' | 'C', 'G' | 'G', 'C' -> true | _ -> false

// the logic is:
// find all perfect matchings, so every nuc must be matched
// for each nuc, find all matches where the distance between is even (so matches can run internally) and the distance after is even (so it can be matched after)
// these finds represent possibilities, so they will be multiplied by further matches, which means sum then multiply by after
// for both internal and external (after) of each possibility, rerun the algorithm gathering other possibilities
// if a matching has a distance of zero (i.e. next to each other) return 1

let cache = System.Collections.Generic.Dictionary<int * int, bigint>()

let rec calc low high = 
    printfn "calc %i %i" low high
    match cache.TryGetValue ((low, high)) with
    | true, v -> v
    | _ ->
        let aggregrator index = 
            if not (paired rna.[low] rna.[index]) then 
                printfn "%i %i not paired so 0" low index
                bigint 0
            else if index - low = 1 then 
                printfn "%i %i paired and next so 1" low index
                bigint 1
            else
                printfn "multiplying for %i %i times %i %i" (low + 1) (index - 1) (index + 1) high
                calc (low + 1) (index - 1) * calc (index + 1) high
        let result = List.sumBy aggregrator [low + 1..2..high]
        cache.Add((low, high), result)
        result

let result = calc 0 (rna.Length - 1)
printfn "Result: %A" result

// Inspired by: https://adijo.github.io/2016/01/13/rosalind-catalan-numbers-and-rna-secondary-structures/