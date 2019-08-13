
#load "../fasta.fs"

// let input = """
// >Rosalind_57
// AUAU
// """
let input = """
>Rosalind_1001
GAAACUAGCGAUCGUAAUUAUUUAUACGAUCGCGCGUAAACGCGUAUGCCGCGGCUCCGC
GGAUAUUAGCUCGCCGGGCCUCGAUUCUAGUAAACGACGUUAUUCGCAGUACUGUAGCUA
CUAGGGUAUACCCUAGCGAUUUAAAAUUGCAUAUAUCGAUGUACCGAAAGCUAUUAUCUA
GCGAUCCUGCGUACGAUCGCAGUACCGCGCGAUGUCGACGACGUCGAUCCGGGGAUCCCG
CGGGCGACGUCCGCGCGGCGCUAGAAUUCCGGCGCAGUAAUUUAAGCCCGCUUAAG
"""

let parsed = Fasta.parse input
let rna = snd parsed.[0]

let paired = 
    function
    | 'A', 'U' | 'U', 'A' | 'C', 'G' | 'G', 'C' -> true
    | _ -> false

let folder (unmatched, count) c = 
    match unmatched, c with
    | [], _ -> [c], count
    | last::rest, c when paired (last, c) -> rest, count + bigint 1
    | _ -> c::unmatched, count

let _, result = Seq.fold folder ([], bigint 0) rna
printfn "Result: %A" result

let fact n = if n = 0 then bigint 1 else List.reduce (*) [bigint 1..bigint n]
let catalan n = fact (2 * n) / (fact (n + 1) * fact n)

let test = catalan rna.Length
printfn "Test: %A" test