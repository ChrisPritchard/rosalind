open System

#load "../fasta.fs"

let input = """
>Rosalind_56
ATTAGACCTG
>Rosalind_57
CCTGCCGGAA
>Rosalind_58
AGACCTGCCG
>Rosalind_59
GCCGGAATAC
"""
//let input = System.IO.File.ReadAllText "./input.txt"

let dna = Fasta.parse input |> List.map snd

let links = 
    dna 
    |> List.map (fun left ->
        left, 
        dna |> List.choose (fun right -> 
            if left = right then None
            else
                [1..left.Length-2] 
                |> List.map (fun i -> left.[i..])
                |> List.tryFind (right.StartsWith)
                |> Option.map (fun subSet -> right, subSet)))
    |> Map.ofList

let shortest start = 
    let next current exclude =
        match List.except exclude links.[current] with
        | [] -> None
        | set -> Some (List.maxBy (snd >> fun (s: string) -> s.Length) set)
    let rec expand soFar =
        if List.length soFar = dna.Length then 
            let result =
                ("", soFar) ||> List.fold (fun acc -> 
                    function 
                    | token, "" -> token + acc 
                    | token, subString -> token.Replace(subString, "") + acc)
            Some result
        else
            let soFar = 
                match soFar with
                | [] -> Some [start, ""]
                | (prev, _)::_ -> 
                    next prev soFar |> Option.bind (fun n -> Some (n::soFar))
            soFar |> Option.bind expand
    expand []

let shortestStart = dna |> List.choose shortest |> List.minBy (fun s -> s.Length)
printfn "%s" shortestStart