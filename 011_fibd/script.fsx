
// n = months, m = life per rabbit pair (including one month prior to breeding age)
let n, m = 98, 16

let alive = Array.create (n + 1) (bigint 0)
let deaths = Array.create (n + m + 2) (bigint 0)

alive.[1] <- bigint 1
deaths.[m + 1] <- bigint 1

for i = 2 to n do
    alive.[i] <- alive.[i - 1] + alive.[i - 2] - deaths.[i]
    deaths.[i + m] <- alive.[i - 1]

printfn "Alive at month %i: %A rabbit pairs" n alive.[n]