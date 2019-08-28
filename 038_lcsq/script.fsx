
#load "../fasta.fs"

let input = """
>Rosalind_23
AACCTTGG
>Rosalind_64
ACACTGTGA
"""
// let input = System.IO.File.ReadAllText "./input.txt"

let contains (subSeq: char[]) (s: string) = 
    let rec searcher subSeqIndex searchStartIndex =
        let next = s.IndexOf(subSeq.[subSeqIndex], searchStartIndex)
        if next = -1 then false
        elif subSeqIndex = subSeq.Length - 1 then true
        else
            searcher (subSeqIndex + 1) (next + 1)
    searcher 0 0

let result = ""

System.IO.File.WriteAllText ("./output.txt", result)
printfn "Result written to output.txt"