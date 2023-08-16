/*

    Finding a Most Likely Common Ancestor

    In “Counting Point Mutations”, we calculated the minimum number of symbol mismatches between two strings of equal length to model the problem of finding the minimum number of point mutations occurring on the evolutionary path between two homologous strands of DNA. If we instead have several homologous strands that we wish to analyze simultaneously, then the natural problem is to find an average-case strand to represent the most likely common ancestor of the given strands.
 */

use crate::util;

const DATASET: &str = include_str!("../datasets/cons.txt");

pub fn solve() {

    let input = util::read_fasta(DATASET);

    let (_, first) = &input[0];
    let mut result = vec![(0,0,0,0); first.len()];

    for (_, sequence) in input.iter() {
        for (i, base) in sequence.chars().enumerate() {
            let (a, c, g, t) = &mut result[i];
            match base {
                'A' => *a += 1,
                'C' => *c += 1,
                'G' => *g += 1,
                'T' => *t += 1,
                _ => panic!("invalid base: {base}"),
            }
        }
    }

    let mut consensus = String::new();
    let mut a_counts = String::from("A: ");
    let mut c_counts = String::from("C: ");
    let mut g_counts = String::from("G: ");
    let mut t_counts = String::from("T: ");

    for (a, c, g, t) in result.iter() {
        let as_slice = [a,c,g,t];
        let max = *as_slice.iter().max().unwrap();
        let top = if max == a {'A'} else if max == c {'C'} else if max == g {'G'} else {'T'};
        consensus.push(top);
        a_counts.push_str(&format!("{a} "));
        c_counts.push_str(&format!("{c} "));
        g_counts.push_str(&format!("{g} "));
        t_counts.push_str(&format!("{t} "));
    }
    
    println!("{consensus}\n{a_counts}\n{c_counts}\n{g_counts}\n{t_counts}")
}