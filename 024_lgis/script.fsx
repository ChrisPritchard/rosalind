open System

// let input = """
// 5
// 5 1 4 2 3
// """
let input = System.IO.File.ReadAllText "./input.txt"

let raw = input.Split ("\r\n ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
let chars = Array.skip 1 raw |> Array.map int |> Array.indexed

let mapped predicate = 
    chars 
    |> Array.map (fun (i, v) -> 
        (i, v), chars |> Array.filter (fun (oi, ov) -> oi > i && predicate v ov))
    |> Map.ofArray

// let longest mapped =
//     let rec explore acc current =
//         let res = Map.find current mapped
//         if Array.isEmpty res then [|acc|]
//         else Array.collect (fun next -> explore (next::acc) next) res
//     chars 
//     |> Array.collect (fun start -> explore [start] start)
//     |> Array.maxBy List.length

let test = mapped (>)
// let long = longest test

// let result = List.map string long |> String.concat " "
printfn "%A" test