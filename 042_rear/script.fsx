
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
    |> Array.map (fun a -> 
        Seq.zip (line a.[0]) (line a.[1]) 
        |> Seq.filter (fun (a, b) -> a <> b) 
        |> Seq.fold (fun (aas, bas) (a, b) -> 
            aas + string a, bas + string b) ("", ""))

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
        let maxSize = a.Length - 1 // max naieve replacements is difference length - 1
        let mutable paths = [|b, Set.ofList [b]|]
        let mutable found = None
        let visited = System.Collections.Generic.HashSet [b]
        
        while found = None do
            let size = Set.count (snd paths.[0])
            printfn "%i: %i" size paths.Length
            if size = maxSize then found <- Some maxSize
            else
                paths <- 
                    paths 
                    |> Array.collect (fun (head, soFar) ->
                        permutations head
                        |> Seq.filter (fun n -> 
                            not (Set.contains n soFar) && 
                            not (visited.Contains n))
                        |> Seq.map (fun n -> 
                            if n = a then found <- Some soFar.Count
                            visited.Add n |> ignore
                            n, Set.add n soFar)
                        |> Seq.toArray)
        match found with Some v -> v | _ -> maxSize

let result = sets |> Seq.map (minReplacements >> string) |> String.concat " "
printfn "Result: %s" result