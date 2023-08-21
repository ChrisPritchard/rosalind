/*

    Searching Through the Haystack

    In “Finding a Motif in DNA”, we searched a given genetic string for a motif; however, this problem assumed that we know the motif in advance. In practice, biologists often do not know exactly what they are looking for. Rather, they must hunt through several different genomes at the same time to identify regions of similarity that may indicate genes shared by different organisms or species.

    The simplest such region of similarity is a motif occurring without mutation in every one of a collection of genetic strings taken from a database; such a motif corresponds to a substring shared by all the strings. We want to search for long shared substrings, as a longer motif will likely indicate a greater shared function.

*/

use crate::util;

const DATASET: &str = include_str!("../datasets/lcsm.txt");

pub fn solve() {
    let fasta = util::read_fasta(DATASET);

    let (_, first) = &fasta[0];

    let mut result = None;
    let mut length = first.len()/3; // just guessing it wont be longer than 33% of the length

    while length > 2 {
        for start in 0..(first.len() - length) {
            let range = &first[start..(start + length)];

            let mut valid = true;
            for i in 1..fasta.len() {
                let (_, sequence) = &fasta[i];
                if !sequence.contains(range) {
                    valid = false;
                    break;
                }
            }
            if valid {
                result = Some(range);
                break;
            } 
        }
        if result.is_some() {
            break;
        }
        length -= 1;
    }

    println!("{}", result.unwrap())
}