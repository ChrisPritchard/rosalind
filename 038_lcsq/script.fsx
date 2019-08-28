
#load "../fasta.fs"

// let input = """
// >Rosalind_23
// AACCTTGG
// >Rosalind_64
// ACACTGTGA
// """
let input = System.IO.File.ReadAllText "./input.txt"

let (s, t) = Fasta.parse input |> List.map snd |> List.toArray |> fun a -> a.[0], a.[1]

// An implementation of the dynamic programming solution defined here: https://en.wikipedia.org/wiki/Longest_common_subsequence_problem

let private commonSuffixLen (x: string) (y: string) =
    let maxSuffix = min x.Length y.Length
    let firstMismatch =
        [1..maxSuffix] 
        |> List.tryFind (fun i -> x.[x.Length - i] <> y.[y.Length - i])
    firstMismatch |> Option.map (fun i -> i - 1) |> Option.defaultValue maxSuffix

let cache = new System.Collections.Generic.Dictionary<_,_>()

let rec lcs (x: string) (y: string) =
    match cache.TryGetValue ((x, y)) with
    | true, cached -> cached
    | false, _ ->
        let result =
            if x.Length = 0 || y.Length = 0 then ""
            else
                let m, n = x.Length - 1, y.Length - 1
                let p = commonSuffixLen x y
                if p > 0 then
                    let before = lcs x.[0..m - p] y.[0..n - p]
                    let after = x.[(x.Length - p)..] 
                    before + after
                else
                    let a = lcs x.[0..m - 1] y
                    let b = lcs x y.[0..n - 1]
                    if a.Length > b.Length then a else b
        cache.Add((x, y), result)
        result
   
let result = lcs s t

// printfn "%s" result

System.IO.File.WriteAllText ("./output.txt", result)
printfn "Result written to output.txt"