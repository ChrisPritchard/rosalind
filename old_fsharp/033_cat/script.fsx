
#load "../fasta.fs"

// let input = """
// >Rosalind_57
// AUAU
// """
let input = """
>Rosalind_8565
AGGGUCGCGUACGAUACUGCAAUCAAAUUAGCUCAUGGCACAUGUGCUAAUGUUACGCGA
CGCGAUCAUGUCUAGACGCAUGACGCGUAUCAUUACGCGUACCGCGGAAUAUAUGUAUAC
AUUACUACGGAUAUCGAUCGAUUGCAUCCGGCAUAUGUAUCCCGGGGCGAUCCGAAUUAA
UUUCGAUAGUAGUACGGCCCAGCGUCGACGCUCAUCCGGGGUUAACGCUAGCGAUCCGGC
CUUAUGGCGCCGCACGCGCUAGUAUAUAACGCGAUUCGGCCUAGAUGAAUCGUCCGUCGA
"""

let parsed = Fasta.parse input
let rna = snd parsed.[0]

let paired a b = match a, b with | 'A', 'U' | 'U', 'A' | 'C', 'G' | 'G', 'C' -> true | _ -> false
let cache = System.Collections.Generic.Dictionary<int * int, bigint>()

let rec count low high = 
    match cache.TryGetValue ((low, high)) with
    | (true, v) -> v
    | _ ->
        let result = 
            [low + 1..2..high]
            |> List.filter (fun i -> paired rna.[low] rna.[i])
            |> List.sumBy (fun i ->
                let inner = if i - low = 1 then bigint 1 else count (low + 1) (i - 1)
                let after = if i = high then bigint 1 else count (i + 1) high
                inner * after)
        cache.Add((low, high), result)
        result

let result = count 0 (rna.Length - 1)
printfn "Result mod 1 mil: %A" (result % bigint 1000000)

// This was a tough one. Got some tips from here: https://adijo.github.io/2016/01/13/rosalind-catalan-numbers-and-rna-secondary-structures/
// Built a version that enumerates the unique sets, instead of just counting them. This was the step that helped me solve it (its copied below).
// The problem page states that catalan numbers can help here (which find non-crossing pairs) but I can't quite see how, given the types of nucleotides
// determine where a given index can be paired with another. Maybe if you could isolate a single nucleotide pair in a subset you could use the catalan
// formula to quickly get the number of non-crossing?

// let rec count low high = 
//     [low + 1..2..high]
//     |> List.filter (fun i -> paired rna.[low] rna.[i])
//     |> List.collect (fun i ->
//         let inner = if i - low = 1 then [""] else count (low + 1) (i - 1)
//         let first = inner |> List.map (fun s -> sprintf "(%c%s%c)" rna.[low] s rna.[i])
//         let after = if i = high then [""] else count (i + 1) high
//         after |> List.collect (fun s -> first |> List.map (fun s2 -> s2 + s))
//     )