
#load "../fasta.fs"

let input = """
>Rosalind_87
CAGCATGGTATCACAGCAGAG
"""
// let input = System.IO.File.ReadAllText "./input.txt"

let W = Fasta.parse input |> List.head |> snd |> fun s -> s.ToCharArray ()
let T = Array.create W.Length 0

// logic:
// have a length index at 0
// if W = T at length then increase length (this means you need something to start at 0?)
// if W <> T at length then reset to 0

// System.IO.File.WriteAllText ("./output.txt", result)
// printfn "Result written to output.txt"