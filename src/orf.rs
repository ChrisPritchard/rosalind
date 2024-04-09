
const DATASET: &str = include_str!("../datasets/orf.txt");

fn rev_complement(dna_strand: &str) -> String {
    dna_strand.chars().rev().map(|nucleobase| {
        match nucleobase {
            'A' => 'T',
            'T' => 'A',
            'G' => 'C',
            'C' => 'G',
            _ => panic!("invalid character in dna string: {}", nucleobase)
        }
    }).collect::<String>()
}

pub fn solve() {
    let dna_strand1 = DATASET.split("\n").nth(1).unwrap();
    let dna_strand2 = rev_complement(dna_strand1);

    let rna_codons = |dna_strand: &str| dna_strand.chars().collect::<Vec<char>>().chunks(3).map(|s| s.iter().collect::<String>().replace("T", "U")).collect::<Vec<_>>();

    let start_codon = "AUG";
    let codon_map = crate::util::codon_map();

    let mut reading = false;
    let mut current_protein = String::new();
    for codon in rna_codons(&dna_strand2) {
        if codon == start_codon {
            reading = true;
        }
        if reading {
            let amino_acid = codon_map.get(&codon).unwrap();
            if amino_acid == "Stop" {
                reading = false;
                println!("{current_protein}");
                current_protein.clear();
            } else {
                current_protein.push_str(&amino_acid);
            }
        }
    }
}