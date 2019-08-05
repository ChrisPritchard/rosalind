open System

// let input = """
// 5
// 5 1 4 2 3
// """
let input = System.IO.File.ReadAllText "./input.txt"

let raw = input.Split ("\r\n ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
let chars = Array.skip 1 raw |> Array.map int |> Array.indexed // index, value

let next (index, value) p = 
    Array.filter (fun (oi, ov) -> oi > index && p value ov) chars

let rec collector acc

let result = ""

System.IO.File.WriteAllText ("./output.txt", result)
printfn "Result written to output.txt"