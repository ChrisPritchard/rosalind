use std::env;


mod util;

fn main() {
    let token = env::args().nth(1).unwrap_or(String::from("")).to_lowercase();
    match token.as_str() {
        "dna"   => dna::solve(),
        "rna"   => rna::solve(),
        "revc"  => revc::solve(),
        "fib"   => fib::solve(),
        "gc"    => gc::solve(),
        "hamm"  => hamm::solve(),
        "iprb"  => iprb::solve(),
        "prot"  => prot::solve(),
        "subs"  => subs::solve(),
        "cons"  => cons::solve(),
        "fibd"  => fibd::solve(),
        "grph"  => grph::solve(),
        "iev"   => iev::solve(),
        "lcsm"  => lcsm::solve(),
        "lia"   => lia::solve(),
        "mprt"  => mprt::solve(),
        "mrna"  => mrna::solve(),
        "orf"   => orf::solve(),
        "perm"  => perm::solve(),
        "prtm"  => prtm::solve(),
        "revp"  => revp::solve(),
        "splc"  => splc::solve(),
        "lexf" | _ => lexf::solve(),
    }
}

mod dna {
    const DATASET: &str = include_str!("../datasets/dna.txt");

    pub fn solve() {
        let mut a = 0;
        let mut c = 0;
        let mut g = 0;
        let mut t = 0;
        for nucleobase in DATASET.chars() {
            match nucleobase {
                'A' => a += 1,
                'C' => c += 1,
                'G' => g += 1,
                'T' => t += 1,
                _ => panic!("invalid character in dna string: {}", nucleobase)
            }
        }
        println!("{a} {c} {g} {t}")
    }
}

mod rna {
    const DATASET: &str = include_str!("../datasets/rna.txt");

    pub fn solve() {
        let rna = DATASET.replace("T", "U");
        println!("{rna}")
    }
}

mod revc {
    const DATASET: &str = include_str!("../datasets/revc.txt");

    pub fn solve() {
        let reverse_complement = DATASET.chars().rev().map(|nucleobase| {
            match nucleobase {
                'A' => 'T',
                'T' => 'A',
                'G' => 'C',
                'C' => 'G',
                _ => panic!("invalid character in dna string: {}", nucleobase)
            }
        }).collect::<String>();
        println!("{reverse_complement}")
    }
}

mod fib {
    const N: i64 = 36;
    const K: i64 = 2;

    pub fn solve() {
        let result = f(N);
        println!("{result}")
    }

    fn f(n: i64) -> i64 {
        if n == 1 || n == 2 {
            1
        } else {
            f(n-1) + f(n-2) * K
        }
    }
}

mod gc {
    use std::collections::HashMap;

    const DATASET: &str = include_str!("../datasets/gc.txt");

    pub fn solve() {
        let fasta = fasta_from(DATASET);
        let (label, gc) = fasta.iter().map(|(label, dna)| (label, gc_from(dna))).max_by(|(_, x), (_, y)| x.total_cmp(&y)).unwrap();
        println!("{label}\n{gc:.6}")
    }

    fn fasta_from(dataset: &str) -> HashMap<String, String> {
        let mut result = HashMap::new();
        let mut current = String::new();
        for line in dataset.lines() {
            if line.starts_with(">") {
                let label = line[1..].to_string();
                result.insert(label.clone(), String::from(""));
                current = label.clone();
            } else {
                result.entry(current.clone()).and_modify(|v| { *v = v.clone() + line; });
            }
        }
        result
    }

    fn gc_from(dna: &str) -> f32 {
        let len = dna.len() as f32;
        let gc = dna.chars().filter(|c| *c != 'T' && *c != 'A').count() as f32;
        (gc / len) * 100.
    }
}

mod hamm {
    const DATASET: &str = include_str!("../datasets/hamm.txt");

    pub fn solve() {
        let lines: Vec<_> = DATASET.lines().collect();
        let fst: Vec<_> = lines[0].chars().collect();
        let snd: Vec<_> = lines[1].chars().collect();

        let mut hamming_distance = 0;
        for i in 0..fst.len() {
            if fst[i] != snd[i] {
                hamming_distance += 1;
            }
        }
        println!("{hamming_distance}");
    }
}

mod iprb {
    const K: f64 = 22.;
    const M: f64 = 20.;
    const N: f64 = 21.;

    pub fn solve() {
        // chance of a dominant allele is the combination of all possibilities
        let chance: f64 = 
            [
                (K / (K + M + N)) * ((K - 1.) / ((K - 1.) + M + N)),            // chance of k + chance of k
                (K / (K + M + N)) * (M / ((K - 1.) + M + N)),                   // chance of k + chance of m
                (K / (K + M + N)) * (N / ((K - 1.) + M + N)),                   // chance of k + chance of n

                (M / (K + M + N)) * (K / (K + (M - 1.) + N)),                   // chance of m + chance of k
                (M / (K + M + N)) * ((M - 1.) / (K + (M - 1.) + N)) * (3./4.),  // chance of m + chance of m * 3/4
                (M / (K + M + N)) * (N / (K + (M - 1.) + N)) * (1./2.),         // chance of m + chance of n * 1/2

                (N / (K + M + N)) * (K / (K + M + (N - 1.))),                   // chance of n + chance of k
                (N / (K + M + N)) * (M / (K + M + (N - 1.))) * (1./2.),         // chance of n + chance of m * 1/2
            ].iter().sum();
        println!("{:.5}", chance)
    }
}

mod prot {
    use crate::util;

    const DATASET: &str = include_str!("../datasets/prot.txt");

    pub fn solve() {
        let codon_map = util::codon_map();
        let genes: Vec<_> = DATASET.chars().collect();
        let codons: Vec<_> = genes.chunks(3).map(|chunk| chunk.iter().collect::<String>()).collect();

        let mut result = String::new();
        for codon in codons.iter() {
            let protein = codon_map.get(codon).unwrap().to_string();
            if protein == "Stop" {
                break;
            }
            result.push_str(&protein);
        }
        println!("{result}")
    }
}

mod subs {
    const DATASET: &str = include_str!("../datasets/subs.txt");

    pub fn solve() {
        let lines: Vec<_> = DATASET.lines().collect();
        let sequence: Vec<_> = lines[0].chars().collect();
        let subsequence: Vec<_> = lines[1].chars().collect();
        
        let mut result = String::new();
        for i in 0..(sequence.len() - subsequence.len()) {
            for j in 0..=subsequence.len() {
                if j == subsequence.len() {
                    result.push_str(&format!("{} ", i + 1));
                } else if sequence[i+j] != subsequence[j] {
                    break;
                }
            }
        }
    
        println!("{result}")
    }
}

mod cons {
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
}

mod fibd {
    use std::collections::HashMap;

    const N: u64 = 83;
    const M: u64 = 16;
    
    pub fn solve() {
        let mut memo: HashMap<u64, u64> = HashMap::new();
        let result = f(N, &mut memo);
        println!("{result}")
    }
    
    fn f(n: u64, memo: &mut HashMap<u64, u64>) -> u64 {
        if memo.contains_key(&n) {
            return memo[&n]
        }
        let res = 
            if n == 1 || n == 2 {
                1
            } else if n <= M {
                f(n-1, memo) + f(n-2, memo) // no deaths
            } else if n == M + 1 {
                f(n-1, memo) + f(n-2, memo) - 1 // first rabbit pair dies
            } else {
                f(n-1, memo) + f(n-2, memo) - f(n-(M+1), memo)
            };
        memo.insert(n, res);
        res
    }
}

mod grph {
    use crate::util;

    const DATASET: &str = include_str!("../datasets/grph.txt");
    
    const OVERLAP: usize = 3;
    
    pub fn solve() {
        // this is actually not too difficult - its all matching adjacencies, not trying to get a unique loop (which would require a BFS approach)
    
        let fasta = util::read_fasta(DATASET);
        let nodes: Vec<_> = fasta.iter().map(|(label, sequence)| (label, sequence[0..OVERLAP].to_string(), sequence[sequence.len()-OVERLAP..].to_string())).collect();
    
        let mut result = Vec::new();
        nodes.iter().for_each(|(label, _, end)| {
            let adjacencies: Vec<_> = nodes.iter().filter(|(other, start, _)| other != label && start == end).map(|(other, _, _)| (label.to_string(), other.to_string())).collect();
            result.extend(adjacencies);
        });
    
        for (first, second) in result {
            println!("{first} {second}")
        }
    }
}

mod iev {
    const DATASET: [u64;6] = [19050, 16369, 17124, 18143, 16385, 16297];

    const ODDS: [f64;6] = [1., 1., 1., 3./4., 1./2., 0.]; // AA-AA, AA-Aa, AA-aa, Aa-Aa, Aa-aa, aa-aa
    
    pub fn solve() {
        let mut result = 0.;
        for i in 0..=5 {
            let count = DATASET[i] as f64 * ODDS[i] * 2.; // two children per couple
            result += count;
        }
    
        println!("{result}")
    }
}

mod lcsm {
    use crate::util::*;

    const DATASET: &str = include_str!("../datasets/lcsm.txt");
    
    pub fn solve() {
        let fasta = read_fasta(DATASET);
    
        let num_to_check = 3; // this could check all, fasta.len(), but 3 is usually enough
    
        let mut root = SuffixTree::new();
        for (i, (_, sequence)) in fasta.iter().enumerate().take(num_to_check) {
            general_suffix_tree(&mut root, sequence.to_string(), i);
        }
        let result = longest_common_substring(&root, 0, num_to_check);//fasta.len());
        println!("{result}");
    
        // slightly faster, brute force appoach:
    
        // let (_, first) = &fasta[0];
    
        // let mut result = None;
        // let mut length = first.len()/3; // just guessing it wont be longer than 33% of the length
    
        // while length > 2 {
        //     for start in 0..(first.len() - length) {
        //         let range = &first[start..(start + length)];
    
        //         let mut valid = true;
        //         for i in 1..fasta.len() {
        //             let (_, sequence) = &fasta[i];
        //             if !sequence.contains(range) {
        //                 valid = false;
        //                 break;
        //             }
        //         }
        //         if valid {
        //             result = Some(range);
        //             break;
        //         } 
        //     }
        //     if result.is_some() {
        //         break;
        //     }
        //     length -= 1;
        // }
    
        // println!("{}", result.unwrap())
    }
}

mod lia {
    use std::collections::HashMap;

    const K: u32 = 6;
    const N: u32 = 16;
    
    fn fact(n: u32, mem: &mut HashMap<u32, f64>) -> f64 {
        if n == 1 || n == 0 {
            1.
        } else if mem.contains_key(&n) {
            mem[&n].clone()
        } else {
            let res = n as f64 * fact(n-1, mem);
            mem.insert(n, res.clone());
            res
        }
    }
    
    
    fn binomial_coefficient(n: u32, r: u32, mem: &mut HashMap<u32, f64>) -> f64 {
        fact(n, mem) / (fact(r, mem) * fact(n - r, mem))
    }
    
    pub fn solve() {
        let mut mem = HashMap::new();
    
        // probability a child is Aa Bb
        let target_prob: f64 = 0.25; // 0.5 * 0.5
        // find the total possible offspring at gen K
        let children: u32 = 2;
        let total_offspring = children.pow(K);
    
        // calculate probability of at least N children
        // by summing probability for each count of AaBb in the final set (that has at least N)
        let mut total_prob: f64 = 0.0;
        
        for r in N..=total_offspring {
            let possible_ways_to_get_r = binomial_coefficient(total_offspring, r, &mut mem);
            let prob_of_r_target = target_prob.powi(r as i32);
            let prob_of_n_minus_r_not_target = (1. - target_prob).powi((total_offspring-r) as i32);
    
            let chance = possible_ways_to_get_r * prob_of_r_target * prob_of_n_minus_r_not_target;
    
            total_prob += chance;
        }
    
        println!("{:.3}", total_prob);
    }
}

mod mprt {
    use std::{error::Error, io::{Read, Write}, net::TcpStream};

    const DATASET: &str = include_str!("../datasets/mprt.txt");
    
    fn get_key(name: &str) -> &str {
        name.split("_").nth(0).unwrap()
    }
    
    fn download_content(host: &str, path: &str) -> Result<String, Box<dyn Error>> {
        let mut stream = TcpStream::connect(host)?;
    
        let request = format!("GET {path} HTTP/1.1\r\nHost: {host}\r\nConnection: close\r\n\r\n");
        stream.write_all(request.as_bytes())?;
    
        let mut buffer = Vec::new();
        stream.read_to_end(&mut buffer)?;
    
        let result = std::str::from_utf8(&buffer)?;
        let result = result.split("\r\n\r\n").last().unwrap();
        Ok(result.to_string())
    }
    
    enum PatternRules {
        Char(char),
        Not(Vec<char>),
        Any(Vec<char>)
    } 
    
    fn parse_pattern(pattern: &str) -> Vec<PatternRules> {
        let mut result = Vec::new();
    
        let mut in_not = false;
        let mut in_any = false;
        let mut current_set = Vec::new();
        for c in pattern.chars() {
            match c {
                '[' => in_any = true,
                ']' => { in_any = false; result.push(PatternRules::Any(current_set.clone())); current_set.clear() },
                '{' => in_not = true,
                '}' => { in_not = false; result.push(PatternRules::Not(current_set.clone())); current_set.clear() },
                c if in_not || in_any => current_set.push(c),
                c => result.push(PatternRules::Char(c))
            }
        }
    
        result
    }
    
    fn find_pattern(source: &str, pattern: &Vec<PatternRules>) -> Vec<usize> {
        let mut result = Vec::new();
        let source_chars: Vec<char> = source.chars().collect();
    
        'pattern_search: for i in 0..source_chars.len() {
            for j in 0..pattern.len() {
                if i+j == source_chars.len() {
                    return result;
                }
                let c = source_chars[i+j];
                match &pattern[j] {
                    PatternRules::Char(c2) if *c2 == c => continue,
                    PatternRules::Any(opt) if opt.contains(&c) => continue,
                    PatternRules::Not(opt) if !opt.contains(&c) => continue,
                    _ => continue 'pattern_search,
                }
            }
            result.push(i+1); // 1 based
        }
        result
    }
    
    pub fn solve() {
        let pattern = parse_pattern("N{P}[ST]{P}");
    
        for entry in DATASET.split("\n") {
            let key = get_key(entry).trim();
            let data = download_content("rest.uniprot.org:80", &format!("/uniprotkb/{key}.fasta"));
            if let Ok(data) = data {
                let lines = data.split("\n");
                let source = lines.skip(1).collect::<String>();
                let positions = find_pattern(&source, &pattern);
                if positions.len() > 0 {
                    println!("{entry}");
                    let positions = positions.iter().map(|p| p.to_string() + " ").collect::<String>();
                    println!("{positions}");
                }
            }
        } 
    }
}

mod mrna {
    const DATASET: &str = include_str!("../datasets/mrna.txt");

    pub fn solve() {
        let condon_map = crate::util::codon_map();
        let for_protein = |p| condon_map.iter().filter(|&(_, v)| v != "Stop" && v.chars().nth(0).unwrap() == p).map(|(codon, _)| codon.clone()).collect::<Vec<String>>();
    
        let protein_counts = DATASET.chars().map(|c| for_protein(c).len());
        let possible_stop_proteins = 3;
        let total_mod_1mil = protein_counts.fold(possible_stop_proteins, |sum, n| (sum * n) % 1_000_000);
        
        println!("{:?}", total_mod_1mil);
    }
}

mod orf {
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
}

mod perm {

    const N: usize = 6;

    // note for this one, output can be huge so you might need to save to a file
    // if you do, ensure the file is utf-8 (not utf16lle) and LF (not CRLF) or else it will be rejected
    // the incorrect formats for me came from running via powershell on windows, which defaults to the windows format
    
    pub fn solve() {
        println!("{}", (2..=N).product::<usize>());
        iterate(N, &mut Vec::new())
    }
    
    fn iterate(max: usize, so_far: &mut Vec<usize>) {
        for i in 1..=max {
            if so_far.contains(&i) {
                continue;
            }
            let mut new_so_far = so_far.clone();
            new_so_far.push(i);
            if new_so_far.len() == max {
                let final_result: String = new_so_far.iter().map(|i| i.to_string() + " ").collect();
                println!("{}", final_result.trim())
            } else {
                iterate(max, &mut new_so_far.clone())
            }
        }
    }
}

mod prtm {

    const DATASET: &str = include_str!("../datasets/prtm.txt");

    pub fn solve() {
        let map = crate::util::monoisotopic_mass_table();
        let sum : f64 = DATASET.chars().map(|c| map[&c]).sum();
        println!("{sum:.3}")
    }
}

mod revp {
    use crate::util::{read_fasta, rev_complement};

    const DATASET: &str = include_str!("../datasets/revp.txt");
    
    pub fn solve() {
        let fasta = read_fasta(DATASET);
        let dna = &fasta.first().unwrap().1;
        let dna: Vec<_> = dna.chars().collect();
        
        let rev_palindrome_test = |index: usize| {
            for j in 4..=12 {
                if index+j > dna.len() {
                    break;
                }
                let to_test = &dna[index..index+j].iter().collect::<String>();
                if *to_test == rev_complement(&to_test) {
                    println!("{} {}", index+1, to_test.len())
                }
            }
        };
    
        for i in 0..dna.len() {
            rev_palindrome_test(i)
        }
    }
}

mod splc {
    use crate::util;


    const DATASET: &str = include_str!("../datasets/splc.txt");
    
    pub fn solve() {
        let fasta = util::read_fasta(DATASET);
        let mut dna = fasta[0].1.clone();
        for i in 1..fasta.len() {
            dna = dna.replace(&fasta[i].1, "")
        }
        let rna = dna.replace("T", "U");
        let protein = util::translate_rna(&rna);
        println!("{protein}")
    }
}

mod lexf {
    pub fn solve() {
        println!("test")
    }
}