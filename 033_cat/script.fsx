
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

let (&=&) a b = match a, b with | 'A', 'U' | 'U', 'A' | 'C', 'G' | 'G', 'C' -> true | _ -> false

let rec crawler low high = 
    [low + 1..high]
    |> List.sumBy (fun i ->
        if rna.[low] &=& rna.[i] then
            if high - low <= 1 then bigint 1
            else if high - low % 2 <> 0 then bigint 0
            else
                crawler (low + 1) (i - 1) * crawler i high
        else bigint 0)

let result = crawler 0 (rna.Length - 1)
printfn "Result: %A" result

// Inspired by: https://adijo.github.io/2016/01/13/rosalind-catalan-numbers-and-rna-secondary-structures/