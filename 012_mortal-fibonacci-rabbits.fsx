
(*
Mortal Fibonacci Rabbits:

In “Rabbits and Recurrence Relations”, we mentioned the disaster caused by introducing European rabbits into Australia. By the turn of the 20th Century, the situation was so out of control that the creatures could not be killed fast enough to slow their spread (see Figure 1).

The conclusion? Build a fence! The fence, intended to preserve the sanctity of Western Australia, was completed in 1907 after undergoing revisions to push it back as the bunnies pushed their frontier ever westward (see Figure 2). If it sounds like a crazy plan, the Australians at the time seem to have concurred, as shown by the cartoon in Figure 3.

By 1950, Australian rabbits numbered 600 million, causing the government to decide to release a virus (called myxoma) into the wild, which cut down the rabbits until they acquired resistance. In a final Hollywood twist, another experimental rabbit virus escaped in 1991, and some resistance has already been observed.

The bunnies will not be stopped, but they don't live forever, and so in this problem, our aim is to expand Fibonacci's rabbit population model to allow for mortal rabbits.
*)

let n, m = 98, 16
//let n, m = 6, 3 // months, life

let alive = Array.create (n + 1) (bigint 0)
let deaths = Array.create (n + m + 2) (bigint 0)

alive.[2] <- bigint 2
deaths.[m + 1] <- bigint 2

for i = 3 to n do
    alive.[i] <- alive.[i - 1] + alive.[i - 2] - deaths.[i]
    deaths.[i + (m - 1)] <- alive.[i - 2]

printfn "Alive at month %i: %A rabbits" n alive.[n]