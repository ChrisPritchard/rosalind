open System

let input = """
5
5 1 4 2 3
"""

let raw = input.Split ("\r\n ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
let chars = Array.skip 1 raw |> Array.map int |> Array.toList

let rec processor (rem: int list) (acc: int list list) predicate =
    match rem with
    | [] ->
        acc |> Seq.maxBy List.length |> Seq.map string |> Seq.rev |> String.concat " "
    | n::rem ->
        let appended =
            List.map (function 
                | p::rest when predicate p n -> n::p::rest
                | o -> o) acc
        let acc = [n]::appended
        processor rem acc predicate

let inc = processor chars [] (fun p n -> n > p)
let dec = processor chars [] (fun p n -> n < p)
let result = inc + "\r\n" + dec

System.IO.File.WriteAllText ("./output.txt", result)
printfn "Result written to output.txt"