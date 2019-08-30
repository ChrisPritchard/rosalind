
let input = """
90000 0.6
ATAGCCGA
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

//taken from my lia solution
let mutable factCache = [0., 1.] |> Map.ofList
let rec fact (n: float) = 
    match Map.tryFind n factCache with
    | Some v -> v
    | _ ->
        let v = n * fact (n - 1.)
        factCache <- Map.add n v factCache
        v


let pmf p k n = 
    let n = float n
    let k = float k
    // binomial coefficient (from n choose k)
    let nCk = fact k / (fact n * fact (k - n))
    nCk * (p ** n) * ((1. - p) ** (k - n))  

let result = [1..N] |> List.sumBy (fun k -> pmf p N k)
printfn "%f" result

type Foo = Foo of name:string * count:int