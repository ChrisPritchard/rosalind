open System

let input = """
5
5 1 4 2 3
"""

let raw = input.Split ("\r\n ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
let chars = Array.skip 1 raw |> Array.map int |> Array.toList

let rec processor (rem: int list) (decAcc: int list list) (incAcc: int list list) =
    match rem with
    | [] ->
        let inc = Seq.map string incAcc.[0] |> Seq.rev |> String.concat " "
        let dec = Seq.map string decAcc.[0] |> Seq.rev |> String.concat " "
        inc + "\r\n" + dec
    | n::rem ->
        let decAcc = 
            List.choose (function 
                | p::rest when p > n -> Some (n::p::rest)
                | _ -> None) decAcc
            |> function [] -> [[n]] | o -> o
        let incAcc = 
            List.choose (function 
                | p::rest when p < n -> Some (n::p::rest)
                | _ -> None) incAcc
            |> function [] -> [[n]] | o -> o
        processor rem decAcc incAcc

let result = processor chars [] []

System.IO.File.WriteAllText ("./output.txt", result)
printfn "Result written to output.txt"