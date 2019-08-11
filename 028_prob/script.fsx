open System

// let input = """
// ACGATACAA
// 0.129 0.287 0.423 0.476 0.641 0.742 0.783
// """
let input = """
GGAGTAGAAAGAGGACCTGAGAGATGGGGGTGCTCACTCTGTTAACCGACCCTGCTACTAACCGGGTTCCTAGCCGATCGACCACAAGAGGCGTCGAC
0.085 0.133 0.163 0.228 0.289 0.354 0.391 0.457 0.504 0.567 0.622 0.636 0.710 0.760 0.831 0.856 0.937
"""

let lines = input.Split ("\r\n ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)

let dna = lines.[0]
let A = Array.map float lines.[1..]

let chance a =
    let gc = a/2.
    let at = (1.-a)/2.
    dna 
    |> Seq.sumBy (function 
        | 'A' | 'T' -> log10 at 
        | 'G' | 'C' -> log10 gc 
        | c -> failwith ("invalid char: " + string c))
    |> fun o -> Math.Round (o, 3)

let B = Array.map chance A
let result = B |> Array.map string |> String.concat " " 
printfn "Result: %s" result