
#load "../fasta.fs"

let input = """
>Rosalind_23
AACCTTGG
>Rosalind_64
ACACTGTGA
"""
// let input = System.IO.File.ReadAllText "./input.txt"

let (s, t) = Fasta.parse input |> List.map snd |> List.toArray |> fun a -> a.[0].ToCharArray(), a.[1].ToCharArray()

// An implementation of the dynamic programming solution defined here: https://en.wikipedia.org/wiki/Longest_common_subsequence_problem

let rec lcs (x: 'T[]) (y: 'T[]) =
    if x.Length = 0 || y.Length = 0 then 0
    else
        let m, n = x.Length - 1, y.Length - 1
        let p =
            [0..min m n] |> List.tryFind (fun i -> x.[m - i] <> y.[n - i]) |> Option.defaultValue 0
        if p > 0 then
            (lcs x.[0..m - p] y.[0..n - p]) + p
        else
            let a = lcs x.[0..m - 1] y
            let b = lcs x y.[0..n - 1]
            max a b
    
let result = lcs s t

printfn "%A" result

// System.IO.File.WriteAllText ("./output.txt", result)
// printfn "Result written to output.txt"