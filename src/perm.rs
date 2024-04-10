
const N: usize = 3;

pub fn solve() {
    let mut fact = N;
    for i in 2..fact {
        fact *= i;
    }
    println!("{fact}")


}