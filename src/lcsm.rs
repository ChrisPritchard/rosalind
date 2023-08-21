/*

    Searching Through the Haystack

    In “Finding a Motif in DNA”, we searched a given genetic string for a motif; however, this problem assumed that we know the motif in advance. In practice, biologists often do not know exactly what they are looking for. Rather, they must hunt through several different genomes at the same time to identify regions of similarity that may indicate genes shared by different organisms or species.

    The simplest such region of similarity is a motif occurring without mutation in every one of a collection of genetic strings taken from a database; such a motif corresponds to a substring shared by all the strings. We want to search for long shared substrings, as a longer motif will likely indicate a greater shared function.

*/

use crate::util;

const DATASET: &str = include_str!("../datasets/lcsm.txt");

pub fn solve() {
    let fasta = util::read_fasta(DATASET);

    // for a and b, representing index 0 and index len - 1 of the first fasta
    // test the resulting substring against all remaining fasta
    // if in all remaining, its the largest and break

    let (_, first) = &fasta[0];

    let mut result = None;

    for a in 0..first.len() {
        let mut b = first.len() - 1;
        while b > a {
            let range = &first[a..=b];
            let mut valid = true;
            for i in 1..fasta.len() {
                let (_, sequence) = &fasta[i];
                if !sequence.contains(range) {
                    valid = false;
                    break;
                }
            }
            if !valid {
                b -= 1;
                continue;
            } 
            if result.is_none() {
                result = Some(range);
            } else if let Some(last) = result {
                if last.len() < range.len() {
                    result = Some(range);
                }
            }
            break;
        }
    }

    println!("{}", result.unwrap())
}