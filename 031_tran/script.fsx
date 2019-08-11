
#load "../fasta.fs"

// let input = """
// >Rosalind_0209
// GCAACGCACAACGAAAACCCTTAGGGACTGGATTATTTCGTGATCGTTGTAGTTATTGGA
// AGTACGGGCATCAACCCAGTT
// >Rosalind_2200
// TTATCTGACAAAGAAAGCCGTCAACGGCTGGATAATTTCGCGATCGTGCTGGTTACTGGC
// GGTACGAGTGTTCCTTTGGGT
// """
let input = System.IO.File.ReadAllText "./input.txt"

let parsed = Fasta.parse input |> List.map snd
let target, source = parsed.[0], parsed.[1]

let transitions, transversions =
    ((0, 0), Seq.zip target source)
    ||> Seq.fold (fun (ts, tv) -> 
        function
        | e1, e2 when e1 = e2 -> ts, tv
        | 'A', 'G' | 'G', 'A' | 'C', 'T' | 'T', 'C' -> ts + 1, tv
        | _ -> ts, tv + 1)

let result = float transitions / float transversions
printfn "Result: %f" result