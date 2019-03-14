module Fasta

open System

let parse (s:string) = 
    let components = 
        s.Split ([|"\r"; "\n"; " "|], StringSplitOptions.RemoveEmptyEntries)
        |> List.ofArray
    let rec parse name dna (lines: string list) acc =
        match lines with
        | [] -> acc [(name, dna)]
        | head::tail ->
            if name = "" then
                parse (head.Substring 1) "" tail acc
            elif head.[0] = '>' then
                parse (head.Substring 1) "" tail (fun next -> acc ((name, dna)::next))
            else
                parse name (dna + head) tail acc
    parse "" "" components id            