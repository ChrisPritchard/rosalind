/*
Introduction to Mendelian Inheritance

Figure 1. A Punnett square representing the possible outcomes of crossing a heterozygous organism (Yy) with a homozygous recessive organism (yy); here, the dominant allele Y corresponds to yellow pea pods, and the recessive allele y corresponds to green pea pods.

Modern laws of inheritance were first described by Gregor Mendel (an Augustinian Friar) in 1865. The contemporary hereditary model, called blending inheritance, stated that an organism must exhibit a blend of its parent's traits. This rule is obviously violated both empirically (consider the huge number of people who are taller than both their parents) and statistically (over time, blended traits would simply blend into the average, severely limiting variation).

Mendel, working with thousands of pea plants, believed that rather than viewing traits as continuous processes, they should instead be divided into discrete building blocks called factors. Furthermore, he proposed that every factor possesses distinct forms, called alleles.

In what has come to be known as his first law (also known as the law of segregation), Mendel stated that every organism possesses a pair of alleles for a given factor. If an individual's two alleles for a given factor are the same, then it is homozygous for the factor; if the alleles differ, then the individual is heterozygous. The first law concludes that for any factor, an organism randomly passes one of its two alleles to each offspring, so that an individual receives one allele from each parent.

Mendel also believed that any factor corresponds to only two possible alleles, the dominant and recessive alleles. An organism only needs to possess one copy of the dominant allele to display the trait represented by the dominant allele. In other words, the only way that an organism can display a trait encoded by a recessive allele is if the individual is homozygous recessive for that factor.

We may encode the dominant allele of a factor by a capital letter (e.g., A
) and the recessive allele by a lower case letter (e.g., a

). Because a heterozygous organism can possess a recessive allele without displaying the recessive form of the trait, we henceforth define an organism's genotype to be its precise genetic makeup and its phenotype as the physical manifestation of its underlying traits.

The different possibilities describing an individual's inheritance of two alleles from its parents can be represented by a Punnett square; see Figure 1 for an example.
 */

const K: f64 = 22.;
const M: f64 = 20.;
const N: f64 = 21.;

pub fn solve() {
    // chance of a dominant allele is the combination of all possibilities
    let chance: f64 = 
        [
            (K / (K + M + N)) * ((K - 1.) / ((K - 1.) + M + N)),            // chance of k + chance of k
            (K / (K + M + N)) * (M / ((K - 1.) + M + N)),                   // chance of k + chance of m
            (K / (K + M + N)) * (N / ((K - 1.) + M + N)),                   // chance of k + chance of n

            (M / (K + M + N)) * (K / (K + (M - 1.) + N)),                   // chance of m + chance of k
            (M / (K + M + N)) * ((M - 1.) / (K + (M - 1.) + N)) * (3./4.),  // chance of m + chance of m * 3/4
            (M / (K + M + N)) * (N / (K + (M - 1.) + N)) * (1./2.),         // chance of m + chance of n * 1/2

            (N / (K + M + N)) * (K / (K + M + (N - 1.))),                   // chance of n + chance of k
            (N / (K + M + N)) * (M / (K + M + (N - 1.))) * (1./2.),         // chance of n + chance of m * 1/2
        ].iter().sum();
    println!("{:.5}", chance)
}