
#load "../fasta.fs"

// let input = """
// >Rosalind_52
// TCATC
// >Rosalind_44
// TTCAT
// >Rosalind_68
// TCATC
// >Rosalind_28
// TGAAA
// >Rosalind_95
// GAGGA
// >Rosalind_66
// TTTCA
// >Rosalind_33
// ATCAA
// >Rosalind_21
// TTGAT
// >Rosalind_18
// TTTCC
// """
let input = System.IO.File.ReadAllText "./input.txt"

let parsed = Fasta.parse input

let revc: string -> string = 
    Seq.rev 
    >> Seq.map (function
    | 'A' -> 'T'
    | 'C' -> 'G'
    | 'T' -> 'A'
    | 'G' -> 'C'
    | _ -> failwith "invalid")
    >> Seq.toArray >> System.String

let hamm s1 s2 =
    Seq.zip s1 s2 
    |> Seq.filter (fun (a, b) -> a <> b) 
    |> Seq.length

let rna = parsed |> List.map snd
let grouped = rna |> List.groupBy (fun read -> Array.sort [|read; revc read|])
let candidates = grouped |> List.choose (fun (_, instances) -> match instances with [justOne] -> Some justOne | _ -> None)
let asSet = Set.ofList candidates

let result = 
    candidates 
    |> List.map (fun read -> 
        let other = 
            rna 
            |> List.except candidates
            |> List.distinctBy (fun other -> Array.sort [|other; revc other|])
            |> List.pick (fun other -> if hamm other read = 1 || hamm (revc other) read = 1 then Some other else None)
        sprintf "%s->%s" read other)
    |> String.concat "\r\n"

System.IO.File.WriteAllText ("./output.txt", result)
printfn "Result written to output.txt"