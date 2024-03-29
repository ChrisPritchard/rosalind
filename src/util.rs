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

pub struct SuffixTree {
    nodes: Vec<char>,
    children: Vec<Vec<usize>>,
    sources: Vec<Vec<usize>>,
}

impl SuffixTree {
    pub fn new() -> Self {
        Self {
            nodes: vec!['^'],
            children: vec![vec![]],
            sources: vec![vec![]],
        }
    }
    fn add_node(&mut self, c: char, parent_index: usize) -> usize {
        let new_index = self.nodes.len();
        self.nodes.push(c);
        self.children.push(Vec::new());
        self.sources.push(Vec::new());
        self.children[parent_index].push(new_index);
        return new_index;
    }
}

fn attach(tree: &mut SuffixTree, source_index: usize, node_index: usize, chars: &[char]) {
    if !tree.sources[node_index].contains(&source_index) {
        tree.sources[node_index].push(source_index);
    }

    if chars.len() == 0 {
        return;
    }

    let child = tree.children[node_index].iter().map(|index| (index, tree.nodes[*index])).find(|(_, c)| c == &chars[0]);
    if let Some((index, _)) = child {
        attach(tree, source_index, *index, &chars[1..]);
    } else {
        let new_index = tree.add_node(chars[0], node_index);
        attach(tree, source_index, new_index, &chars[1..]);
    }
}

pub fn general_suffix_tree(existing_tree: &mut SuffixTree, source: String, source_index: usize) {
    let chars: Vec<_> = source.chars().collect();
    let mut i = chars.len();

    while i > 0 {
        i -= 1;
        attach(existing_tree, source_index, 0, &chars[i..])
    }
}

pub fn longest_common_substring(tree: &SuffixTree, node_index: usize, source_count: usize) -> String {
    tree.children[node_index].iter()
        .filter(|child_index| tree.sources[**child_index].len() == source_count)
        .map(|child_index| tree.nodes[node_index].to_string() + &longest_common_substring(tree, *child_index, source_count))
        .max_by(|a, b| a.len().cmp(&b.len()))
        .unwrap_or(tree.nodes[node_index].to_string())
        .trim_start_matches('^')
        .to_string()
}