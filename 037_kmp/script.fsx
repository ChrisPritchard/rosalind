
#load "../fasta.fs"

let input = """
>Rosalind_87
CAGCATGGTATCACAGCAGAG
"""
//let input = System.IO.File.ReadAllText "./input.txt"

let W = Fasta.parse input |> List.head |> snd |> fun s -> s.ToCharArray ()
let T = Array.create W.Length -1
T.[0] <- 0

let mutable pos, len = 1, 0
while pos < W.Length do
    if W.[len] = W.[pos] then
        len <- len + 1
        T.[pos] <- len
    elif len = 0 then
        T.[pos] <- 0
    else
        len <- T.[len - 1]
        pos <- pos - 1
    pos <- pos + 1

let result = T |> Array.map string |> String.concat " "

printfn "derived: %s" result
printfn "tocheck: 0 0 0 1 2 0 0 0 0 0 0 1 2 1 2 3 4 5 3 0 0"
printfn "checked: %b" (result = "0 0 0 1 2 0 0 0 0 0 0 1 2 1 2 3 4 5 3 0 0")

// System.IO.File.WriteAllText ("./output.txt", result)
// printfn "Result written to output.txt"