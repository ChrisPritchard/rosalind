/*

    Evolution as a Sequence of Mistakes
    Figure 1. A point mutation in DNA changing a C-G pair to an A-T pair.

    A mutation is simply a mistake that occurs during the creation or copying of a nucleic acid, in particular DNA. Because nucleic acids are vital to cellular functions, mutations tend to cause a ripple effect throughout the cell. Although mutations are technically mistakes, a very rare mutation may equip the cell with a beneficial attribute. In fact, the macro effects of evolution are attributable by the accumulated result of beneficial microscopic mutations over many generations.

    The simplest and most common type of nucleic acid mutation is a point mutation, which replaces one base with another at a single nucleotide. In the case of DNA, a point mutation must change the complementary base accordingly; see Figure 1.

    Two DNA strands taken from different organism or species genomes are homologous if they share a recent ancestor; thus, counting the number of bases at which homologous strands differ provides us with the minimum number of point mutations that could have occurred on the evolutionary path between the two strands.

    We are interested in minimizing the number of (point) mutations separating two species because of the biological principle of parsimony, which demands that evolutionary histories should be as simply explained as possible.

*/

const DATASET: &str = include_str!("../datasets/hamm.txt");

pub fn solve() {
    let lines: Vec<_> = DATASET.lines().collect();
    let fst: Vec<_> = lines[0].chars().collect();
    let snd: Vec<_> = lines[1].chars().collect();

    let mut hamming_distance = 0;
    for i in 0..fst.len() {
        if fst[i] != snd[i] {
            hamming_distance += 1;
        }
    }
    println!("{hamming_distance}");
}