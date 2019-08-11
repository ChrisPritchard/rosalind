open System

//let n, k = 21, 7
let n, k = 97, 10


let start = (n - k) + 1
let permutations = [bigint start..bigint n] |> List.reduce (*)
let mod1mil = permutations % bigint 1000000

printfn "Result: %A" mod1mil