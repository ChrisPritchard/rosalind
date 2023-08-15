use std::collections::HashMap;


pub fn read_fasta(source: &str) -> Vec<(String, String)> {
    let mut result = Vec::new();
    
    let mut current_label = String::new();
    let mut current_sequence = String::new();
    
    for line in source.lines() {
        if line.starts_with(">") {
            if current_label.len() > 0 {
                result.push((current_label, current_sequence))
            }
            let label = line[1..].to_string();
            current_label = label;
            current_sequence = String::new();
        } else {
            current_sequence += line;
        }
    }
    result.push((current_label, current_sequence));
    result
}

pub fn codon_map() -> HashMap<String, String> {
    let mut result = HashMap::new();

    let lines = 
"UUU F      CUU L      AUU I      GUU V
UUC F      CUC L      AUC I      GUC V
UUA L      CUA L      AUA I      GUA V
UUG L      CUG L      AUG M      GUG V
UCU S      CCU P      ACU T      GCU A
UCC S      CCC P      ACC T      GCC A
UCA S      CCA P      ACA T      GCA A
UCG S      CCG P      ACG T      GCG A
UAU Y      CAU H      AAU N      GAU D
UAC Y      CAC H      AAC N      GAC D
UAA Stop   CAA Q      AAA K      GAA E
UAG Stop   CAG Q      AAG K      GAG E
UGU C      CGU R      AGU S      GGU G
UGC C      CGC R      AGC S      GGC G
UGA Stop   CGA R      AGA R      GGA G
UGG W      CGG R      AGG R      GGG G".lines();
    for line in lines {
        let parts: Vec<_> = line.split_whitespace().collect();
        for i in (0..=6).step_by(2) {
            result.insert(parts[i].to_string(), parts[i + 1].to_string());
        }
    }
    result
}