
let input = """
6 3 5 7 8 10 1 4 2 9
3 5 2 7 8 1 9 6 4 10

6 1 9 2 10 7 5 4 3 8
4 2 1 3 6 5 10 7 9 8

6 4 10 5 9 2 3 7 8 1
2 1 10 9 5 6 7 4 3 8

3 1 4 7 6 2 10 5 8 9
4 3 6 1 10 7 8 2 9 5

5 3 8 1 6 10 9 7 2 4
5 10 2 8 1 3 4 9 7 6
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

// This is a slow and brute-force solution, but it works. Its also my tenth version, 
// but the first after I read the problem properly: I initially thought the only changes
// allowed were character swaps - however a reversal is actually ANY SIZE subsection reversed.