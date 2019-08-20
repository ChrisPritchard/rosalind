
#load "../fasta.fs"

let input = """
>Rosalind_57
AUGCAU
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

let rec count low high = 
    [low + 1..2..high]
    |> List.filter (fun i -> paired rna.[low] rna.[i])
    |> List.collect (fun i ->
        let inner = if i - low = 1 then [""] else count (low + 1) (i - 1)
        let first = inner |> List.map (fun s -> sprintf "(%c%s%c)" rna.[low] s rna.[i])
        let after = if i = high then [""] else count (i + 1) high
        after |> List.collect (fun s -> first |> List.map (fun s2 -> s2 + s))
    )

let result = count 0 (rna.Length - 1)// |> List.length
printfn "Result mod 1 mil:\r\n%A" (String.concat "\r\n" result)//(result % 1000000)

// Inspired by: https://adijo.github.io/2016/01/13/rosalind-catalan-numbers-and-rna-secondary-structures/