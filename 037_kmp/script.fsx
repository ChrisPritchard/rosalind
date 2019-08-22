
#load "../fasta.fs"

let input = """
>Rosalind_87
CAGCATGGTATCACAGCAGAG
"""
// let input = System.IO.File.ReadAllText "./input.txt"

let W = Fasta.parse input |> List.head |> snd |> fun s -> s.ToCharArray ()
let T = Array.create W.Length 0
T.[0] <- -1

let mutable pos, cnd = 1, 0
while pos < W.Length do
    if W.[pos] = W.[cnd] then T.[pos] <- T.[cnd]
    else
        T.[pos] <- cnd
        cnd <- T.[cnd]
        while cnd >= 0 && W.[pos] <> W.[cnd] do
            cnd <- T.[cnd]
    pos <- pos + 1
    cnd <- cnd + 1

//T.[pos] <- cnd

let result = 
    T
    |> Array.map string
    |> String.concat " "

printfn "%s" result

// System.IO.File.WriteAllText ("./output.txt", result)
// printfn "Result written to output.txt"