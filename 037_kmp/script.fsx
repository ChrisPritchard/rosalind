
#load "../fasta.fs"

let input = """
>Rosalind_87
CAGCATGGTATCACAGCAGAG
"""
// let input = System.IO.File.ReadAllText "./input.txt"

let dna = Fasta.parse input |> List.head |> snd

let result = 
    [0..dna.Length - 1] 
    |> List.map (fun k -> 
        [(k - 1)..(-1)..0] 
        |> List.tryFind (fun j -> 
            dna.[(k-j)..k] = dna.[0..j])
        |> Option.map (fun j -> j + 1)
        |> Option.defaultValue 0
        |> string)
    |> String.concat " "

printfn "%s" result

// System.IO.File.WriteAllText ("./output.txt", result)
// printfn "Result written to output.txt"