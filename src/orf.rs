use crate::util;


const DATASET: &str = include_str!("../datasets/orf.txt");

pub fn solve() {
    let dna_strand1 = &util::read_fasta(DATASET)[0].1;
    let dna_strand2 = &util::rev_complement(dna_strand1);

    let reading_frame_rna_codons = |dna_strand: &str, offset: usize| 
        dna_strand.chars()
            .skip(offset).collect::<Vec<char>>()
            .chunks(3).map(|s| s.iter().collect::<String>().replace("T", "U"))
            .collect::<Vec<_>>();

    let start_codon = "AUG";
    let codon_map = util::codon_map();
    let mut found_proteins = Vec::new();

    for strand in [&dna_strand1, &dna_strand2] {
        for frame in 0..=2 {
            let codons = reading_frame_rna_codons(strand, frame);
            for i in 0..codons.len() {
                if codons[i] == start_codon {
                    let mut protein = String::new();
                    for j in i..codons.len() {
                        let amino_acid = codon_map.get(&codons[j]).unwrap();
                        if amino_acid == "Stop" {
                            found_proteins.push(protein);
                            break;
                        } else {
                            protein.push_str(&amino_acid);
                        }
                    }
                }
            }
        }
    }

    found_proteins.sort();
    found_proteins.dedup();
    for protein in found_proteins {
        println!("{protein}");
    }
}