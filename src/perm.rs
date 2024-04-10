
const N: usize = 6;

// note for this one, output can be huge so you might need to save to a file
// if you do, ensure the file is utf-8 (not utf16lle) and LF (not CRLF) or else it will be rejected
// the incorrect formats for me came from running via powershell on windows, which defaults to the windows format

pub fn solve() {
    let mut fact = N;
    for i in 2..fact {
        fact *= i;
    }
    println!("{fact}");

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