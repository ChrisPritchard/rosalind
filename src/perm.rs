
const N: usize = 3;

pub fn solve() {
    let mut fact = N;
    for i in 2..fact {
        fact *= i;
    }
    println!("{fact}");

    iterate(N, 1)
}

fn iterate(max: usize, index: usize) {
    for i in 1..=max {
        print!("{i} ");
        if index == max {
            println!();
        }
        else {
            iterate(max, index + 1);
        }
    }
}