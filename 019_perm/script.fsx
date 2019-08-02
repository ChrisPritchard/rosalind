
let input = 3

let set = [1..input]

let rec permute = 
    function
    | [] -> []
    | head::rest ->
        permute rest |> List.map (fun tail -> head::tail)

let results = permute set |> List.toArray

printfn "%i" results.Length
for result in results do
    printfn "%s" (result |> List.map string |> String.concat "")