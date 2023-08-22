use std::{collections::{HashMap, HashSet}, fmt::Display};


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
    sources: HashSet<usize>,
    children: HashMap<char, SuffixNode>
}

impl SuffixNode {
    pub fn new(initial_source_index: usize) -> Self {
        let mut sources = HashSet::new();
        sources.insert(initial_source_index);
        Self { sources, children: HashMap::new() }
    }
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

fn attach(source_index: usize, node: &mut SuffixNode, chars: &[char]) {
    if !node.sources.contains(&source_index) {
        node.sources.insert(source_index);
    }

    if chars.len() == 0 {
        let new_child = SuffixNode::new(source_index);
        node.children.insert('$', new_child);
        return;
    }

    let first = chars[0].clone();

    if node.children.contains_key(&chars[0]) {
        attach(source_index, &mut node.children.get_mut(&first).unwrap(), &chars[1..]);
    } else {
        let mut new_child = SuffixNode::new(source_index);
        attach(source_index, &mut new_child, &chars[1..]);
        node.children.insert(first, new_child);
    }
}

pub fn general_suffix_tree(existing_tree: &mut SuffixNode, source: String, source_index: usize) {
    let chars: Vec<_> = source.chars().collect();
    let mut i = chars.len();

    while i > 0 {
        i -= 1;
        attach(source_index, existing_tree, &chars[i..])
    }
}

pub fn longest_common_substring(node: &SuffixNode, source_count: usize) -> String {

    node.children.iter()
        .filter(|(_, node)| node.sources.len() == source_count)
        .map(|(c, node)|
            String::from(*c) + &longest_common_substring(node, source_count)
        ).max_by(|a, b| a.len().cmp(&b.len()))
        .unwrap_or(String::from(""))
}