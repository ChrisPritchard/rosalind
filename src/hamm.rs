
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