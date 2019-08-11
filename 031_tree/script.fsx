
// let input = """
// 10
// 1 2
// 2 8
// 4 10
// 5 9
// 6 10
// 7 9
// """
let input = System.IO.File.ReadAllText "./input.txt"

let parsed = input.Split ("\r\n ".ToCharArray (), System.StringSplitOptions.RemoveEmptyEntries) |> Array.map int
let all = [1..parsed.[0]] |> Set.ofList
let adjacencies = parsed.[1..] |> Seq.chunkBySize 2 |> Seq.map (fun a -> a.[0], a.[1]) |> Seq.toList

let rec group acc unfound rem =
    match rem with
    | [] -> List.length acc - 1 + Set.count unfound
    | (a, b)::rem ->
        let acc = 
            if Set.contains a unfound && Set.contains b unfound then Set.ofList [a;b]::acc
            else acc |> List.map (fun set -> 
                if set.Contains a then set.Add b 
                elif set.Contains b then set.Add a 
                else set)
        let unfound = Set.remove a unfound |> Set.remove b
        group acc unfound rem

let result = group [] all adjacencies
printfn "Result: %A" result