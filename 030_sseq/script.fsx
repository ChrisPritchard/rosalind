
#load "../fasta.fs"

// let input = """
// >Rosalind_14
// ACGTACGTGACG
// >Rosalind_18
// GTA
// """
let input = System.IO.File.ReadAllText "./input.txt"

let parsed = Fasta.parse input |> List.map snd
let target, source = parsed.[0], parsed.[1] |> Seq.map string |> Seq.toList

let rec indices acc (start: int) (rem: string list) =
    match rem with
    | [] -> List.rev acc
    | next::rem ->
        let index = target.IndexOf (next, start)
        indices (index + 1::acc) (index + 1) rem

let result = indices [] 0 source |> Seq.map string |> String.concat " "
printfn "Result: %s" result