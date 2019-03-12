open System.IO

[<EntryPoint>]
let main _ =

    let map =
        File.ReadAllText "./rosalind_dna.txt"
        |> Seq.countBy id
        |> Map.ofSeq
    printfn "%i %i %i %i" map.['A'] map.['C'] map.['G'] map.['T']

    0