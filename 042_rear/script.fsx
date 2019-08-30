
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

let minReversals (a: string, b: string) =
    
    let visited = System.Collections.Generic.HashSet<_> [a]

    let allReversals (s: string) =
        [|
            for i in [0..s.Length - 1] do
                for j = 1 to s.Length - 1 - i do 
                    let section = s.ToCharArray().[i..i+j] |> Array.rev |> System.String
                    let result = 
                        if section.Length = s.Length then section
                        else if i = 0 then section + s.[section.Length..]
                        else if s.Length - section.Length = i then s.[0..i-1] + section
                        else s.[0..i-1] + section + s.[j+i+1..]
                    if not (visited.Contains result) then
                        visited.Add result |> ignore
                        yield result
        |]

    let mutable paths = [|a|]
    let mutable reversals = 0
    while not (visited.Contains b) do
        paths <- Array.collect allReversals paths
        reversals <- reversals + 1
    reversals

let result = sets |> Seq.map (minReversals >> string) |> String.concat " "
printfn "Result: %s" result