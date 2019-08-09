open System

#load "../fasta.fs"

let input = """
>Rosalind_23
AGCUAGUCAU
"""
//let input = System.IO.File.ReadAllText "./input.txt"

let dna = snd (Fasta.parse input).[0]
let tagged = dna |> Seq.indexed |> Seq.toArray
let opposite = function 'A' -> 'U' | 'U' -> 'A' | 'C' -> 'G' | 'G' -> 'C' | c -> failwith ("invalid char: " + string c)
let allEdges = 
    tagged 
    |> Array.collect (fun (i, n) -> 
        tagged 
        |> Array.choose (fun (oi, on) -> 
            if on = opposite n 
            then  Some ((i, n), (oi, on))
            else None))

let (_, result) = 
    ((Set.empty, 0), allEdges)
    ||> Seq.fold (fun (visited, count) (node1, node2) -> 
        if visited.Contains node1 || visited.Contains node2 then visited, count
        else (Set.add node1 visited |> Set.add node2), count + 1)

printfn "Result: %i" result