
(*
Identifying Unknown DNA Quickly:

A quick method used by early computer software to determine the language of a given piece of text was to analyze the frequency with which each letter appeared in the text. This strategy was used because each language tends to exhibit its own letter frequencies, and as long as the text under consideration is long enough, software will correctly recognize the language quickly and with a very low error rate. See Figure 1 for a table compiling English letter frequencies.

You may ask: what in the world does this linguistic problem have to do with biology? Although two members of the same species will have different genomes, they still share the vast percentage of their DNA; notably, 99.9% of the 3.2 billion base pairs in a human genome are common to almost all humans (i.e., excluding people having major genetic defects). For this reason, biologists will speak of the human genome, meaning an average-case genome derived from a collection of individuals. Such an average case genome can be assembled for any species, a challenge that we will soon discuss.

The biological analog of identifying unknown text arises when researchers encounter a molecule of DNA from an unknown species. Because of the base pairing relations of the two DNA strands, cytosine and guanine will always appear in equal amounts in a double-stranded DNA molecule. Thus, to analyze the symbol frequencies of DNA for comparison against a database, we compute the molecule's GC-content, or the percentage of its bases that are either cytosine or guanine.

In practice, the GC-content of most eukaryotic genomes hovers around 50%. However, because genomes are so long, we may be able to distinguish species based on very small discrepancies in GC-content; furthermore, most prokaryotes have a GC-content significantly higher than 50%, so that GC-content can be used to quickly differentiate many prokaryotes and eukaryotes by using relatively small DNA samples.
*)

open System.IO
#load "./fasta.fs"

let sample = File.ReadAllText "./005_input.txt"
let fasta = Fasta.parse sample

let gcPercent (dna:string) = 
    let byLetter = dna |> Seq.countBy id |> Map.ofSeq
    (float (byLetter.['G'] + byLetter.['C']) / float dna.Length) * 100.

fasta
|> List.map (fun (name, dna) -> name, gcPercent dna)
|> List.maxBy snd
|> fun (name, gc) -> printfn "Result:\r\n%s\r\n%f" name gc