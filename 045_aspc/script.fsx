
let n, m = 6, 3

let fact (n: float) = if n = 0. then 1. else List.reduce (*) [1.0..n]
let nCk n k = 
    let n = float n
    let k = float k
    fact n / (fact k * fact (n - k))

let result = [m..n] |> List.sumBy (nCk n) |> int
printfn "Result: %A" result