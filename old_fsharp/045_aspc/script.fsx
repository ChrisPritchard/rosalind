
//let n, m = 6, 3
let n, m = 1876, 827

let fact (n: bigint) = 
    if n = bigint 0 then bigint 1 
    else List.reduce (*) [bigint 1..n]

let nCk n k = fact n / (fact k * fact (n - k))

let result = [m..n] |> List.sumBy (fun k -> nCk (bigint n) (bigint k))
printfn "Result: %A" (result % bigint 1_000_000)