open System

// let input = """
// 5
// 5 1 4 2 3
// """
let input = System.IO.File.ReadAllText "./input.txt"

let raw = input.Split ("\r\n ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
let chars = Array.skip 1 raw |> Array.map int |> Array.toList

let rec processor (rem: int list) (acc: int list list) predicate =
    match rem with
    | [] ->
        let res = acc |> Seq.groupBy List.length |> Seq.maxBy fst |> snd |> Seq.last
        res |> Seq.map string |> Seq.rev |> String.concat " "
    | n::rem ->
        let appended =
            List.collect (function 
            | p::rest when predicate p n -> [p::rest; n::p::rest]
            | o -> [o]) acc
        let acc = [n]::appended
        processor rem acc predicate

let inc = processor chars [] (fun p n -> n > p)
let dec = processor chars [] (fun p n -> n < p)
let result = inc + "\r\n" + dec

System.IO.File.WriteAllText ("./output.txt", result)
printfn "Result written to output.txt"