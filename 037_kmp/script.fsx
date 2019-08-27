
#load "../fasta.fs"

// let input = """
// >Rosalind_87
// CAGCATGGTATCACAGCAGAG
// """
let input = System.IO.File.ReadAllText "./input.txt"

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
            len <- T.[len - 1]
            pos <- pos - 1
    pos <- pos + 1

let result = T |> Array.map string |> String.concat " "

System.IO.File.WriteAllText ("./output.txt", result)
printfn "Result written to output.txt"