
//let k, N = 2, 1
let k, N = 7, 38

let pAaBa = 0.25 // key insight is that Aa Ba is 0.25 from Aa Ba, regardless of generation or mate
let countAtK = 2. ** float k

/// Simple (not super efficient) Factorial function
let fact (n: float) = if n = 0. then 1. else List.reduce (*) [1.0..n]

/// Probability Mass Function (PMF)
let pmf n = 
    let n = float n
    /// binomial coefficient (from n choose k)
    let nCk = fact countAtK / (fact n * fact (countAtK - n))
    nCk * (pAaBa ** n) * ((1. - pAaBa) ** (countAtK - n))    

let result = [N..int countAtK] |> List.sumBy pmf // Also key, the result is N or more, so N to max should be summed

printfn "result: %f" result