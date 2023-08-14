
//let k, m, n = 2, 2, 2
let k, m, n = 15, 23, 21

type Genes = FAA | FAa | Faa
let population = Array.concat [| Array.create k FAA; Array.create m FAa; Array.create n Faa |] |> Array.indexed
let matingPairs = 
    population 
    |> Array.collect (fun (i1, first) ->
        population 
        |> Array.filter (fun (i2, _) -> i2 <> i1 )
        |> Array.map (fun (_, second) -> first, second))
let result = 
    matingPairs 
    |> Array.sumBy (function 
        | (FAA, _) | (_, FAA) -> 1. / float matingPairs.Length
        | (FAa, FAa) -> 0.75 / float matingPairs.Length
        | (FAa, _) | (_, FAa) -> 0.5 / float matingPairs.Length
        | _ -> 0.)

printfn "Result: %f" result