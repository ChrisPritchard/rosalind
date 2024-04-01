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

fn find_pattern(source: &str, pattern: Vec<PatternRules>) -> Vec<usize> {
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
    let source = "MLGVLVLGALALAGLGFPAPAEPQPGGSQCVEHDCFALYPGPATFLNASQICDGLRGHLMTVRSSVAADVISLLLNGDGGVGRRRLWIGLQLPPGCGDPKRLGPLRGFQWVTGDNNTSYSRWARLDLNGAPLCGPLCVAVSAAEATVPSEPIWEEQQCEVKADGFLCEFHFPATCRPLAVEPGAAAAAVSITYGTPFAARGADFQALPVGSSAAVAPLGLQLMCTAPPGAVQGHWAREAPGAWDCSVENGGCEHACNAIPGAPRCQCPAGAALQADGRSCTASATQSCNDLCEHFCVPNPDQPGSYSCMCETGYRLAADQHRCEDVDDCILEPSPCPQRCVNTQGGFECHCYPNYDLVDGECVEPVDPCFRANCEYQCQPLNQTSYLCVCAEGFAPIPHEPHRCQMFCNQTACPADCDPNTQASCECPEGYILDDGFICTDIDECENGGFCSGVCHNLPGTFECICGPDSALARHIGTDCDSGKVDGGDSGSGEPPPSPTPGSTLTPPAVGLVHSGLLIGISIASLCLVVALLALLCHLRKKQGAARAKMEYKCAAPSKEVVLQHVRTERTPQRL";
    let pattern = parse_pattern("N{P}[ST]{P}");
    println!("{:?}", find_pattern(source, pattern));
}