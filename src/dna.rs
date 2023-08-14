
const DATASET: &str = include_str!("../datasets/dna.txt");

pub fn solve() {
    let mut a = 0;
    let mut c = 0;
    let mut g = 0;
    let mut t = 0;
    for nucleobase in DATASET.chars() {
        match nucleobase {
            'A' => a += 1,
            'C' => c += 1,
            'G' => g += 1,
            'T' => t += 1,
            _ => panic!("invalid character in dna string: {}", nucleobase)
        }
    }
    println!("{a} {c} {g} {t}")
}