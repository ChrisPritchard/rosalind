// http://rosalind.info/problems/iprb/

(*
Introduction to Mendelian Inheritance:

Modern laws of inheritance were first described by Gregor Mendel (an Augustinian Friar) in 1865. The contemporary hereditary model, called blending inheritance, stated that an organism must exhibit a blend of its parent's traits. This rule is obviously violated both empirically (consider the huge number of people who are taller than both their parents) and statistically (over time, blended traits would simply blend into the average, severely limiting variation).

Mendel, working with thousands of pea plants, believed that rather than viewing traits as continuous processes, they should instead be divided into discrete building blocks called factors. Furthermore, he proposed that every factor possesses distinct forms, called alleles.

In what has come to be known as his first law (also known as the law of segregation), Mendel stated that every organism possesses a pair of alleles for a given factor. If an individual's two alleles for a given factor are the same, then it is homozygous for the factor; if the alleles differ, then the individual is heterozygous. The first law concludes that for any factor, an organism randomly passes one of its two alleles to each offspring, so that an individual receives one allele from each parent.

Mendel also believed that any factor corresponds to only two possible alleles, the dominant and recessive alleles. An organism only needs to possess one copy of the dominant allele to display the trait represented by the dominant allele. In other words, the only way that an organism can display a trait encoded by a recessive allele is if the individual is homozygous recessive for that factor.

We may encode the dominant allele of a factor by a capital letter (e.g., A
) and the recessive allele by a lower case letter (e.g., a

). Because a heterozygous organism can possess a recessive allele without displaying the recessive form of the trait, we henceforth define an organism's genotype to be its precise genetic makeup and its phenotype as the physical manifestation of its underlying traits.

The different possibilities describing an individual's inheritance of two alleles from its parents can be represented by a Punnett square; see Figure 1 for an example.    
*)

(*
Given: Three positive integers k, m, and n, representing a population containing k+m+n organisms: k individuals are homozygous dominant for a factor, m are heterozygous, and n are homozygous recessive.
Return: The probability that two randomly selected mating organisms will produce an individual possessing a dominant allele (and thus displaying the dominant phenotype). Assume that any two organisms can mate
*)

//let k, m, n = 2, 2, 2
let k, m, n = 15, 23, 21

// Verbose calculation:

// type Genes = FAA | FAa | Faa
// let population = Array.concat [| Array.create k FAA; Array.create m FAa; Array.create n Faa |] |> Array.indexed
// let matingPairs = 
//     population 
//     |> Array.collect (fun (i1, first) ->
//         population 
//         |> Array.filter (fun (i2, _) -> i2 <> i1 )
//         |> Array.map (fun (_, second) -> first, second))
// let result = 
//     matingPairs 
//     |> Array.sumBy (function 
//         | (FAA, _) | (_, FAA) -> 1. / float matingPairs.Length
//         | (FAa, FAa) -> 0.75 / float matingPairs.Length
//         | (FAa, _) | (_, FAa) -> 0.5 / float matingPairs.Length
//         | _ -> 0.)

// Concise calculation

let pop = (k + m + n) * (k + m + n - 1)

let fk, fm, fn = float k, float m, float n
let success = 
        (fk * (fk-1.)) + (fk * fm) + (fk * fn)
        + (fm * fk) + (fm * (fm-1.) * 0.75) + (fm * fn * 0.5)
        + (fn * fk) + ((fn * fm) * 0.5)
let result = success / float pop

printfn "Result: %f" result