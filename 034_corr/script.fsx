
#load "../fasta.fs"

let input = """
>Rosalind_52
TCATC
>Rosalind_44
TTCAT
>Rosalind_68
TCATC
>Rosalind_28
TGAAA
>Rosalind_95
GAGGA
>Rosalind_66
TTTCA
>Rosalind_33
ATCAA
>Rosalind_21
TTGAT
>Rosalind_18
TTTCC
"""
// let input = System.IO.File.ReadAllText "./input.txt"

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
let grouped = rna |> List.countBy id
let asSet = rna |> Set.ofList

let (errored, valid) =
     (([], []), grouped) ||>
     List.fold(fun (errored, valid) (read, instances) -> 
        if instances > 1 then errored, read::valid
        elif asSet.Contains (revc read) then errored, read::valid
        else 
            let other = rna |> List.choose (fun s -> 
                if hamm s read = 1 then Some s
                else
                    let revc = revc s 
                    if hamm revc read = 1 then Some revc
                    else None) |> List.distinct
            match other with
            | [justOne] -> (read, justOne)::errored, valid
            | _ -> errored, read::valid)

let result = 
    errored 
    |> List.map (fun (read, other) -> sprintf "%s->%s" read other)
    |> String.concat "\r\n"

System.IO.File.WriteAllText ("./output.txt", result)
printfn "Result written to output.txt"