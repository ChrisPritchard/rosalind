(*
    Combing through the Haystack:

    Finding the same interval of DNA in the genomes of two different organisms (often taken from different species) is highly suggestive that the interval has the same function in both organisms.

We define a motif as such a commonly shared interval of DNA. A common task in molecular biology is to search an organism's genome for a known motif.

The situation is complicated by the fact that genomes are riddled with intervals of DNA that occur multiple times (possibly with slight modifications), called repeats. These repeats occur far more often than would be dictated by random chance, indicating that genomes are anything but random and in fact illustrate that the language of DNA must be very powerful (compare with the frequent reuse of common words in any human language).

The most common repeat in humans is the Alu repeat, which is approximately 300 bp long and recurs around a million times throughout every human genome (see Figure 1). However, Alu has not been found to serve a positive purpose, and appears in fact to be parasitic: when a new Alu repeat is inserted into a genome, it frequently causes genetic disorders.
*)

let s = "CCGCCGGTTTTACCGCCGGATCCGCCGGCCGCCGGAACCGCCGGACCCCGCCGGGAATCCGCCGGCCCGCCGGCACGACATCCGCCGGCCGCCGGTATCCCGCCGGCGGCCGCCGGGACCGCCGGCCGCCGGTCCGCCGGCCGCCGGTAGGCCCGCCGGCCGCCGGAGCTCCGCCGGCCCCGCCGGCCGCCGGTTGGCCCGCCGGAGAGGTGCGCCGCCGGGGCCGCCGGTCCGCCGGGCCGCCGGCCGCCGGGACCGCCGGCCCGCCGGGGAGTCCGCCGGGGCGAGGCCCGCCGGTGCCCCGCCGGCCGCCGGACCAGACCGCCGGTAGAGTGCCGCCGCCGGGTCCGGATGCCGCCGGAACCGCCGGGTCCGCCGGACTGGTTCACCGCCGGGTACCGCCGGATGCCGCCGGCCCGCCGGCCCGCCGGCCGCCGGCCGCCGGACGACCCGCCGGTGCCGCCGGATCTTGATCGCCCGCCGGGCCGCCGGCCCGCCGGTCCCGCCGGCCGCCGGCCGCCGGTTGTCCGCCGGCCGCCGGAGCCGCCGGCCGCCGGCCGCCGGCCCGTCCGCCGGAAGTCCGCCGGGTGTGGCCGCCGGGCCGCCGGCCGCCGGGGCCGCCGGCCGCCGGGACAGCCGCCGGGCCCGCCGGCGAGTTGATCCGCCGGGCCGCCGGCCGCCGGCCGCCGGATCCGCCGGCCCCGCCGGTCCGCCGGTGCCGCCGGTCCGCCGGAGCCGCCGGTTCCGCCGGAAACCGCCGGGGCCGCCGCCGGACCGCCGGACCAACGTCCGCCGGTATCCGCCGGCGTCGCTATGTGCCGCCGGACCGCCGGCCGCCGGGGGCCGCCGGCTCCGCCGGGCCGCCGGTTGTCCGCCGGCCGCCGGCCCCGCCGGACGAAATCCGCCGGGTCGGTCCTCCGCCGGCCGCCGGACCCGCCGGCCGCCGGCGG"
let t = "CCGCCGGCC"

let rec findIndexes acc (i: int) = 
    let next = s.IndexOf (t, i)
    if next = -1 then acc
    else findIndexes ((next + 1)::acc) (next + 1)

findIndexes [] 0 |> List.rev |> List.map string |> String.concat " " |> printfn "%s"
