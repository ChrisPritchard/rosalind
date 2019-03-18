
(*
Searching through the haystack:

In “Finding a Motif in DNA”, we searched a given genetic string for a motif; however, this problem assumed that we know the motif in advance. In practice, biologists often do not know exactly what they are looking for. Rather, they must hunt through several different genomes at the same time to identify regions of similarity that may indicate genes shared by different organisms or species.

The simplest such region of similarity is a motif occurring without mutation in every one of a collection of genetic strings taken from a database; such a motif corresponds to a substring shared by all the strings. We want to search for long shared substrings, as a longer motif will likely indicate a greater shared function.
*)

open System.IO
#load "./fasta.fs"

let s = File.ReadAllText "./014_input.txt"
let fasta = Fasta.parse s

let start = snd fasta.[0]

let invalid (sub: string) = List.tryFind (fun (_, dna: string) -> dna.IndexOf(sub) = -1 ) fasta <> None
let rec longest acc i =
    if i = start.Length then acc
    else
        let next = acc + string start.[i]
        if invalid next then acc
        else
            longest next (i + 1)

let result = 
    start 
    |> Seq.mapi (fun i c -> longest (string c) (i + 1))
    |> Seq.maxBy (fun (sub: string) -> sub.Length, - int sub.[0])

File.WriteAllText ("014_ouput.txt", result)