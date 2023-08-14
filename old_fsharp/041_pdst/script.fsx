#load "../fasta.fs"

// let input = """
// >Rosalind_9499
// TTTCCATTTA
// >Rosalind_0942
// GATTCATTTC
// >Rosalind_6568
// TTTCCATTTT
// >Rosalind_1833
// GTTCCATTTA
// """
let input = System.IO.File.ReadAllText "./input.txt"

let dna = Fasta.parse input |> List.map snd

let hamm source against =
    Seq.zip source against 
    |> Seq.filter (fun (a, b) -> a <> b) 
    |> Seq.length 
    |> fun i -> float i / float (Seq.length source)
    |> fun n -> (System.Math.Round (n, 5)).ToString("F5")

let result = 
    dna 
    |> List.map (fun source -> 
        dna |> List.map (fun against -> hamm source against) |> String.concat " ")
    |> String.concat "\r\n"

//printfn "%s" result

System.IO.File.WriteAllText ("./output.txt", result)
printfn "Result written to output.txt"