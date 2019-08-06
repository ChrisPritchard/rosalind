open System

// let input = """
// 5
// 5 1 4 2 3
// """
let input = System.IO.File.ReadAllText "./input.txt"

// trying to adapt https://www.geeksforgeeks.org/construction-of-longest-increasing-subsequence-using-dynamic-programming/

let raw = input.Split ("\r\n ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
let nums = Array.skip 1 raw |> Array.map int

let res = Array.create nums.Length [nums.[0]]

for i in [1..res.Length - 1] do
    let num = nums.[i]
    let next = 
        match res.[i - 1] with
        | [] -> [num]
        | head::tail when head < num -> num::head::tail
        | _::tail -> num::tail
    res.[i] <- next

printfn "%A" res