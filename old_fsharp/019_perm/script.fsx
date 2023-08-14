
open System.IO

let input = 6

let rec permute =
    function
    | [] -> [[]]
    | set ->
        set 
        |> List.collect (fun n ->
            let rest = List.except [n] set |> permute
            rest |> List.map (fun sub -> n::sub))

let results = permute [1..input] |> Seq.toArray


let o = File.OpenWrite "./output.txt"
let w = new StreamWriter(o)

w.WriteLine results.Length
for result in results do
    w.WriteLine (result |> List.map string |> String.concat " ")

w.Close ()
w.Dispose ()

printfn "Result written to output.txt"