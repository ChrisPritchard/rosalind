
#load "../fasta.fs"

let input = """
>Rosalind_57
AUAUAU
"""



// AU AU AU
// A UA UA U
// AU A UA U
// A UA U AU
// A U AU A U

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
// does this mean we only need to do the first? hmmmmmmmmmmmmmmmmmmmmmm
// what does it mean to calculate matches? its a sum? so all matches times all sub matches for each match * all following matches for each match?
// does that mean count matches, then multiply by inner and outer?

let rec count low high = 
    match cache.TryGetValue ((low, high)) with
    | true, v -> v
    | _ ->
            if low >= high then bigint 0
            else
                let toMatch = rna.[low]
                let matches = Array.filter (fun index -> paired toMatch rna.[index]) [|low + 1..2..high|]
                printfn "%i matches %A" low matches
                let count = 
                    bigint matches.Length 
                    * (Array.map (fun index -> 
                        if index - low = 1 then bigint 1
                        else 
                            let inner = count (low + 1) (index - 1)
                            if index >= high then inner
                            else inner * count index high) matches |> Array.reduce (*))
                
                cache.Add((low, high), count)
                count

let result = count 0 (rna.Length - 1)
printfn "Result mod 1 mil: %A" (result % bigint 1000000)

// Inspired by: https://adijo.github.io/2016/01/13/rosalind-catalan-numbers-and-rna-secondary-structures/