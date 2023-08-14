open System

//let input = 2
let input = 4

let rec permutations acc visited =
    if List.length acc = input then [acc]
    else
        [-input..input]
        |> List.filter (fun n -> n <> 0 && not (Set.contains (abs n) visited))
        |> List.collect (fun n -> permutations (n::acc) (Set.add (abs n) visited))

let formatted = permutations [] Set.empty |> Seq.map (List.map string >> String.concat " ") |> Seq.toArray
let result = sprintf "%i\r\n%s" (formatted.Length) (String.concat "\r\n" formatted)

System.IO.File.WriteAllText ("./output.txt", result)
printfn "Result written to output.txt"