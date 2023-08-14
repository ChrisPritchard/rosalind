
let input = "19409 17310 17826 16271 19888 19841"

// anything with AA is 100% likely to be dominant, so first three numbers will have 2 dominant.
// Aa and Aa is 0.75 likely, so double for 2 children. Aa and aa is 0.5 likely, so again double.
// aa and aa is 0% likely, so 0 even with two children.
let averages = [|2.; 2.; 2.; 1.5; 1.; 0.|]

let result = input.Split [|' '|] |> Array.map float |> Array.zip averages |> Array.sumBy (fun (c, p) -> c * p)

printfn "Expected number of offspring: %f" result