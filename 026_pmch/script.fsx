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

let candidates visited =
    allEdges 
    |> Array.filter (fun (node1, node2) -> 
        not (Set.contains node1 visited) && not (Set.contains node2 visited))

let rec processCandidate count visited (node1, node2) : int =
    let newVisited = Set.add node1 visited |> Set.add node2
    let candidates = candidates newVisited
    if Array.isEmpty candidates then count
    else candidates |> Array.map (processCandidate (count + 1) newVisited) |> Array.max

let result = allEdges |> Array.map (processCandidate 0 Set.empty) |> Array.max
printfn "Result: %i" result