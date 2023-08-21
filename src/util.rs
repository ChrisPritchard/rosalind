use std::{collections::HashMap, fmt::Display};


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

pub struct SuffixNode {
    children: HashMap<char, SuffixNode>
}

impl Display for SuffixNode {
    fn fmt(&self, f: &mut std::fmt::Formatter<'_>) -> std::fmt::Result {
        if self.children.is_empty() {
            return write!(f, "$");
        }

        for (c, child) in self.children.iter() {
            if child.children.is_empty() {
                let _ = write!(f, "{c},");
            } else {
                let _ = write!(f, "{c}({child}),");
            }
        }
        Ok(())
    }
}

fn attach(node: &mut SuffixNode, chars: Vec<char>) {
    if chars.len() == 0 {
        return;
    }

    let first = chars[0].clone();

    if node.children.contains_key(&chars[0]) {
        attach(&mut node.children.get_mut(&first).unwrap(), chars[1..].to_vec());
    } else {
        let mut new_child = SuffixNode { children: HashMap::new() };
        attach(&mut new_child, chars[1..].to_vec());
        node.children.insert(first, new_child);
    }
}

pub fn suffix_tree(s: String) -> SuffixNode {

    let chars: Vec<_> = s.chars().collect();
    let mut root = SuffixNode { children: HashMap::new() };
    let mut i = chars.len();

    while i > 0 {
        i -= 1;
        attach(&mut root, chars[i..].to_vec())
    }
    
    root
}