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

printfn "%A" links