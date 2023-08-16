/*

    Finding a Most Likely Common Ancestor

    In “Counting Point Mutations”, we calculated the minimum number of symbol mismatches between two strings of equal length to model the problem of finding the minimum number of point mutations occurring on the evolutionary path between two homologous strands of DNA. If we instead have several homologous strands that we wish to analyze simultaneously, then the natural problem is to find an average-case strand to represent the most likely common ancestor of the given strands.
 */

use crate::util;

const DATASET: &str = include_str!("../datasets/cons.txt");

pub fn solve() {

    let mut consensus = String::new();
    let mut a_counts = Vec::new();
    let mut c_counts = Vec::new();
    let mut g_counts = Vec::new();
    let mut t_counts = Vec::new();

    let input = util::read_fasta(DATASET);
    let sequences: Vec<_> = input.iter().map(|(_, sequence)| sequence).collect();

    for i in 0..sequences[0].len() {
        let mut a_count = 0;
        let mut c_count = 0;
        let mut g_count = 0;
        let mut t_count = 0;
        let mut max_base = ' ';
        let mut max_count = 0;

        for sequence in sequences.iter() {
            match sequence.chars().nth(i).unwrap() {
                'A' => {
                    a_count += 1;
                    if a_count > max_count {
                        max_base = 'A';
                        max_count = a_count;
                    }
                },
                'C' => {
                    c_count += 1;
                    if c_count > max_count {
                        max_base = 'C';
                        max_count = c_count;
                    }
                },
                'G' => {
                    g_count += 1;
                    if g_count > max_count {
                        max_base = 'G';
                        max_count = g_count;
                    }
                },
                'T' => {
                    t_count += 1;
                    if t_count > max_count {
                        max_base = 'T';
                        max_count = t_count;
                    }
                },
                base => panic!("unknown base: {base}"),
            }
        }

        a_counts.push(a_count);
        c_counts.push(c_count);
        g_counts.push(g_count);
        t_counts.push(t_count);
        consensus.push(max_base);
    }

    println!("{consensus}");
    print!("\tA: ");
    for count in a_counts {
        print!("{count} ");
    }
    println!();
    print!("\tC: ");
    for count in c_counts {
        print!("{count} ");
    }
    println!();
    print!("\tG: ");
    for count in g_counts {
        print!("{count} ");
    }
    println!();
    print!("\tT: ");
    for count in t_counts {
        print!("{count} ");
    }

    println!();
}