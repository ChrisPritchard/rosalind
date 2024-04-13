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

    let mut result = HashMap::new();
    for line in lines {
        let parts: Vec<_> = line.split_whitespace().collect();
        for i in (0..=6).step_by(2) {
            result.insert(parts[i].to_string(), parts[i + 1].to_string());
        }
    }
    result
}

pub fn translate_rna(rna: &str) -> String {
    let codon_map = codon_map();
    let chars: Vec<_> = rna.chars().collect();
    
    let mut i = 0;
    let mut result = String::new();
    let mut translating = false;

    loop {
        if i > chars.len() - 3 {
            break;
        }
        let codon: String = chars[i..=i+2].iter().collect();
        if !translating {
            if codon != "AUG" {
                i += 1;
                continue;
            } else {
                result.push('M');
                translating = true;
                i += 3;
                continue;
            }
        }
        let protein = &codon_map[&codon];
        if protein == "Stop" {
            break;
        }
        result.push_str(&protein);
        i += 3;
    }

    result
}

pub fn monoisotopic_mass_table() -> HashMap<char, f64> {
    let lines = 
"A   71.03711
C   103.00919
D   115.02694
E   129.04259
F   147.06841
G   57.02146
H   137.05891
I   113.08406
K   128.09496
L   113.08406
M   131.04049
N   114.04293
P   97.05276
Q   128.05858
R   156.10111
S   87.03203
T   101.04768
V   99.06841
W   186.07931
Y   163.06333".lines();

    let mut result = HashMap::new();
    for line in lines {
        let parts: Vec<_> = line.split_whitespace().collect();
        result.insert(parts[0].chars().nth(0).unwrap(), parts[1].parse::<f64>().unwrap());
    }
    result
}

pub fn rev_complement(dna_strand: &str) -> String {
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