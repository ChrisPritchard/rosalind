
#load "../fasta.fs"

let input = """
>Rosalind_87
CAGCATGGTATCACAGCAGAG
"""
// let input = System.IO.File.ReadAllText "./input.txt"

let W = Fasta.parse input |> List.head |> snd |> fun s -> s.ToCharArray ()
let T = Array.create W.Length -1
T.[0] <- 0

let mutable pos, len = 1, 0
while pos < W.Length do
    while T.[pos] = -1 do
        if W.[len] = W.[pos] then
            len <- len + 1
            T.[pos] <- len
        elif len = 0 then
            T.[pos] <- 0
        else
            len <- len - 1
    pos <- pos + 1

printfn "%A" T

// logic:
// have a length index at 0
// if W = T at length then increase length (this means you need something to start at 0?)
// if W <> T at length then reset to 0

// System.IO.File.WriteAllText ("./output.txt", result)
// printfn "Result written to output.txt"