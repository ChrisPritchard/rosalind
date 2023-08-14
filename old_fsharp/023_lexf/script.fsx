open System

let input = """
A B C D
4
"""

let raw = input.Split ("\r\n ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
let chars, length = raw.[0..raw.Length - 2], int raw.[raw.Length - 1]

let rec finder acc n =
    if n = 0 then [|acc|]
    else
        chars 
        |> Array.collect (fun c ->
            finder (acc + c) (n - 1))

let result = 
    finder "" length
    |> Array.sort
    |> String.concat "\r\n"

System.IO.File.WriteAllText ("./output.txt", result)
printfn "Result written to output.txt"