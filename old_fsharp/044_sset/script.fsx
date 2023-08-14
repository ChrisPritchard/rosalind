
let input = 921

// this question involves the size of the 'power set', which is just 2^n

let result = bigint.Pow (bigint 2, input) % bigint 1_000_000
printfn "Result: %A" result