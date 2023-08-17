use crate::util;


const DATASET: &str = include_str!("../datasets/grph.txt");

pub fn solve() {
    let fasta = util::read_fasta(DATASET);
    let nodes: Vec<_> = fasta.iter().map(|(label, sequence)| (label, sequence[0..3].to_string(), sequence[sequence.len()-3..].to_string())).collect();
}