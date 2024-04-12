
const DATASET: &str = include_str!("../datasets/prtm.txt");

pub fn solve() {
    let map = crate::util::monoisotopic_mass_table();
    let sum : f64 = DATASET.chars().map(|c| map[&c]).sum();
    println!("{sum:.3}")
}