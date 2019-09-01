
#load "../fasta.fs"

// let input = """
// >Rosalind_39
// PLEASANTLY
// >Rosalind_11
// MEANLY
// """
let input = System.IO.File.ReadAllText "./input.txt"

let target, source = Fasta.parse input |> List.map snd |> fun list -> 
    let a, b = list.[0], list.[1]
    if a.Length > b.Length then a, b else b, a

// lcs implementation taking from lcsq solution

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

let result = target.Length - (lcs source target).Length
printfn "Result: %A" result