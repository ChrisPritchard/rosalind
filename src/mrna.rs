
const DATASET: &str = include_str!("../datasets/mrna.txt");

pub fn solve() {
    let condon_map = crate::util::codon_map();
    let for_protein = |p| condon_map.iter().filter(|&(_, v)| v != "Stop" && v.chars().nth(0).unwrap() == p).map(|(codon, _)| codon.clone()).collect::<Vec<String>>();

    let protein_counts = DATASET.chars().map(|c| for_protein(c).len());
    let possible_stop_proteins = 3;
    let total_mod_1mil = protein_counts.fold(possible_stop_proteins, |sum, n| (sum * n) % 1_000_000);
    
    println!("{:?}", total_mod_1mil);
}