
#load "../fasta.fs"

let input = """
>Rosalind_52
TCATC
>Rosalind_44
TTCAT
>Rosalind_68
TCATC
>Rosalind_28
TGAAA
>Rosalind_95
GAGGA
>Rosalind_66
TTTCA
>Rosalind_33
ATCAA
>Rosalind_21
TTGAT
>Rosalind_18
TTTCC
"""
//let input = System.IO.File.ReadAllText "./input.txt"

let parsed = Fasta.parse input

let revc: string -> string = 
    Seq.rev 
    >> Seq.map (function
    | 'A' -> 'T'
    | 'C' -> 'G'
    | 'T' -> 'A'
    | 'G' -> 'C'
    | _ -> failwith "invalid")
    >> Seq.toArray >> System.String

// let (errored, valid) =
//      (([], []), parsed) ||>
//      List.fold(fun (errored, valid) (_, read) -> 
//         if List.contains read valid then errored, valid
//         else read::errored, valid)