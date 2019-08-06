open System

// let input = """
// 5
// 5 1 4 2 3
// """
let input = System.IO.File.ReadAllText "./input.txt"

// an adaptation of https://www.geeksforgeeks.org/construction-of-longest-increasing-subsequence-using-dynamic-programming/

let raw = input.Split ("\r\n ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
let nums = Array.skip 1 raw |> Array.map int

let subsequence predicate =
    let L = Array.create nums.Length []
    L.[0] <- [nums.[0]]

    for i in [1..L.Length - 1] do
        for j in [0..i-1] do
            if predicate nums.[i] nums.[j] && L.[i].Length < L.[j].Length then
                L.[i] <- L.[j]
        L.[i] <- nums.[i]::L.[i]

    Array.maxBy List.length L

let inc = subsequence (<)
let dec = subsequence (>)
let concat = List.map string >> String.concat " "

let result = sprintf "%s\r\n%s" (concat inc) (concat dec)
System.IO.File.WriteAllText ("./output.txt", result)
printfn "Result written to output.txt"