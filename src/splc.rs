use crate::util;


const DATASET: &str = include_str!("../datasets/splc.txt");

pub fn solve() {
    let fasta = util::read_fasta(DATASET);
    let mut dna = fasta[0].1.clone();
    for i in 1..fasta.len() {
        dna = dna.replace(&fasta[i].1, "")
    }
    let rna = dna.replace("T", "U");
    let protein = util::translate_rna(&rna);
    println!("{protein}")
}