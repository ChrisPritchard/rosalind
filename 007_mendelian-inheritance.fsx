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

let XX, Xy, yy = 29, 30, 25

type Allele = X | Y
let set = 
    List.replicate XX (X,X) @ List.replicate Xy (X,Y) @ List.replicate yy (Y,Y)
    |> List.mapi (fun i g -> g, i)

let rec select (prior: Allele option) list = [
    for ((a21, a22), i) in list do
        match prior with
        | Some a -> 
            yield a,a21
            yield a,a22
        | None ->
            yield! select (Some a21) (List.except [(a21, a22), i] list)
            yield! select (Some a22) (List.except [(a21, a22), i] list)
]

let allOptions = select None set
let result = 
    allOptions
    |> List.filter (fun (a1, a2) -> a1 = X || a2 = X)
    |> List.length
    |> float
    |> fun c -> c / float (List.length allOptions)