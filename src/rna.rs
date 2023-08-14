
const DATASET: &str = include_str!("../datasets/rna.txt");

pub fn solve() {
    let rna = DATASET.replace("T", "U");
    println!("{rna}")
}