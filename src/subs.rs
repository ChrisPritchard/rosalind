/*

    Combing Through the Haystack
    
    Figure 1. The human chromosomes stained with a probe for Alu elements, shown in green.

    Finding the same interval of DNA in the genomes of two different organisms (often taken from different species) is highly suggestive that the interval has the same function in both organisms.

    We define a motif as such a commonly shared interval of DNA. A common task in molecular biology is to search an organism's genome for a known motif.

    The situation is complicated by the fact that genomes are riddled with intervals of DNA that occur multiple times (possibly with slight modifications), called repeats. These repeats occur far more often than would be dictated by random chance, indicating that genomes are anything but random and in fact illustrate that the language of DNA must be very powerful (compare with the frequent reuse of common words in any human language).

    The most common repeat in humans is the Alu repeat, which is approximately 300 bp long and recurs around a million times throughout every human genome (see Figure 1). However, Alu has not been found to serve a positive purpose, and appears in fact to be parasitic: when a new Alu repeat is inserted into a genome, it frequently causes genetic disorders.

*/

const DATASET: &str = include_str!("../datasets/subs.txt");

pub fn solve() {
    let lines: Vec<_> = DATASET.lines().collect();
    let sequence: Vec<_> = lines[0].chars().collect();
    let subsequence: Vec<_> = lines[1].chars().collect();;
    
    let mut result = String::new();
    for i in 0..(sequence.len() - subsequence.len()) {
        for j in 0..=subsequence.len() {
            if j == subsequence.len() {
                result.push_str(&format!("{} ", i + 1));
            } else if sequence[i+j] != subsequence[j] {
                break;
            }
        }
    }

    println!("{result}")
}