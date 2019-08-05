open System

// let input = """
// 5
// 5 1 4 2 3
// """
let input = System.IO.File.ReadAllText "./input.txt"

let raw = input.Split ("\r\n ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
let chars = Array.skip 1 raw |> Array.map int |> Array.toList

let rec options n rem =
    match rem with
    | p::rest when n > p -> rem::options n rest
    | _::rest -> options n rest
    | [] -> []
