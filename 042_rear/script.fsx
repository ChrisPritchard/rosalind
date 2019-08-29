
let input = """
1 2 3 4 5 6 7 8 9 10
3 1 5 2 7 4 9 6 10 8

3 10 8 2 5 4 7 1 6 9
5 2 3 1 7 4 10 8 6 9

8 6 7 9 4 1 3 10 2 5
8 2 7 6 9 1 5 3 10 4

3 9 10 4 1 8 6 7 5 2
2 9 8 5 1 7 3 4 6 10

1 2 3 4 5 6 7 8 9 10
1 2 3 4 5 6 7 8 9 10
"""

let sets = 
    let line (s:string) = s.Replace("10","X").Replace(" ", "")
    input.Split("\r\n".ToCharArray(), System.StringSplitOptions.RemoveEmptyEntries)
    |> Array.chunkBySize 2
    |> Array.map (fun a -> line a.[0], line a.[1])

let permutations (s: string) =
    let swap i j =
        let da = s.ToCharArray ()
        let dai = da.[i]
        da.[i] <- da.[j]
        da.[j] <- dai
        System.String da
    seq {
        for i in [0..s.Length-1] do
            for j in [0..s.Length-1] do
                if i <> j then
                    yield swap i j
    } |> Seq.distinct

let minReplacements (a: string, b: string) =
    if a = b then 0
    else 
        let mutable paths = [[b]]
        let mutable found = None
        while found = None do
            paths <- 
                paths 
                |> List.collect (fun path ->
                    let soFar = Set.ofList path
                    permutations (List.head path)
                    |> Seq.filter (fun n -> not (Set.contains n soFar))
                    |> Seq.map (fun n -> 
                        if n = a then found <- Some soFar.Count
                        n::path)
                    |> Seq.toList)
        found.Value

let result = sets |> Seq.map (minReplacements >> string) |> String.concat " "
printfn "Result: %s" result