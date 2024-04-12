use crate::util::{read_fasta, rev_complement};

const DATASET: &str = include_str!("../datasets/revp.txt");

pub fn solve() {
    let fasta = read_fasta(DATASET);
    let dna = &fasta.first().unwrap().1;
    let dna: Vec<_> = dna.chars().collect();
    
    let rev_palindrome_test = |index: usize| {
        for j in 4..=12 {
            if index+j > dna.len() {
                break;
            }
            let to_test = &dna[index..index+j].iter().collect::<String>();
            if *to_test == rev_complement(&to_test) {
                println!("{} {}", index+1, to_test.len())
            }
        }
    };

    for i in 0..dna.len() {
        rev_palindrome_test(i)
    }
}