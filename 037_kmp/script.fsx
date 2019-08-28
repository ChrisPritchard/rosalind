
#load "../fasta.fs"

// let input = """
// >Rosalind_87
// CAGCATGGTATCACAGCAGAG
// """
let input = System.IO.File.ReadAllText "./input.txt"

let W = (Fasta.parse input |> List.head |> snd).ToCharArray ()
let T = Array.create W.Length 0

let mutable pos, len = 1, 0
while pos < W.Length do
    if W.[len] = W.[pos] then
        T.[pos] <- len + 1
        pos <- pos + 1
        len <- len + 1
    elif len > 0 then
        len <- T.[len - 1]
    else
        T.[pos] <- 0
        pos <- pos + 1


let result = T |> Array.map string |> String.concat " "

// printfn "derived: %s" result
// printfn "tocheck: 0 0 0 1 2 0 0 0 0 0 0 1 2 1 2 3 4 5 3 0 0"
// printfn "checked: %b" (result = "0 0 0 1 2 0 0 0 0 0 0 1 2 1 2 3 4 5 3 0 0")

System.IO.File.WriteAllText ("./output.txt", result)
printfn "Result written to output.txt"