
let input = """
83268 0.568095
GATAATGT
"""

let N, x, s = 
    input.Split("\r\n ".ToCharArray(), System.StringSplitOptions.RemoveEmptyEntries)
    |> fun a -> int a.[0], float a.[1], a.[2]

// taken from my prob solution
let p =
    let gc = x/2.
    let at = (1.-x)/2.
    s 
    |> Seq.map (function 
        | 'A' | 'T' -> at 
        | 'G' | 'C' -> gc 
        | c -> failwith ("invalid char: " + string c))
    |> Seq.reduce (*)

let np = 1. - p // odds of not being equal to s
let NP = Array.create N np |> Array.reduce (*) // odds of N strings ALL not being equal to s
let result = 1. - NP // odds of AT LEAST one string in N being equal to s

printfn "%f" result