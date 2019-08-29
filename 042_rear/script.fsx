
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

let replacements (a: string, b: string) =
    if a = b then 0
    else 
        let visited = System.Collections.Generic.HashSet<_> [b]

        let mutable found = None
        let permutations (s: string) acc = 
            [
                for i in [0..s.Length-1] do
                    for j in [0..s.Length-1] do
                        if i <> j then
                            let da = s.ToCharArray ()
                            let dai = da.[i]
                            da.[i] <- da.[j]
                            da.[j] <- dai
                            let d = System.String da
                            if not (visited.Contains d) then
                                if d = a then 
                                    match found with 
                                    | Some accs when accs > acc -> found <- Some (acc + 1)
                                    | None -> found <- Some (acc + 1)
                                    | _ -> ()
                                visited.Add d |> ignore
                                yield d, acc + 1
            ]

        let rec searcher (options: List<string * int>) =
            if Seq.isEmpty options then found.Value
            else
                let newOptions = List.collect (fun (s, acc) -> permutations s acc) options
                let filteredOptions = 
                    match found with 
                    | Some accs -> List.filter (fun (_, acc) -> acc < accs) newOptions
                    | _ -> newOptions
                searcher filteredOptions
        
        searcher [b, 0]

let result = sets |> Seq.map (replacements >> string) |> String.concat " "
printfn "Result: %s" result