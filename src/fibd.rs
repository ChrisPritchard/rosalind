/*

    Wabbit Season
    
    Figure 1. A c.1905 photo from Australia of a cart loaded to the hilt with rabbit skins.
    Figure 2. Western Australia's rabbit fence is actually not the longest fence in the world as the sign claims. That honor goes to a 3,500 mile fence in southeastern Australia built to keep out dingoes. Courtesy Matt Pounsett.
    Figure 3. An 1884 cartoon from the Queensland Figaro proposing how the rabbits viewed their fence.

    In “Rabbits and Recurrence Relations”, we mentioned the disaster caused by introducing European rabbits into Australia. By the turn of the 20th Century, the situation was so out of control that the creatures could not be killed fast enough to slow their spread (see Figure 1).

    The conclusion? Build a fence! The fence, intended to preserve the sanctity of Western Australia, was completed in 1907 after undergoing revisions to push it back as the bunnies pushed their frontier ever westward (see Figure 2). If it sounds like a crazy plan, the Australians at the time seem to have concurred, as shown by the cartoon in Figure 3.

    By 1950, Australian rabbits numbered 600 million, causing the government to decide to release a virus (called myxoma) into the wild, which cut down the rabbits until they acquired resistance. In a final Hollywood twist, another experimental rabbit virus escaped in 1991, and some resistance has already been observed.

    The bunnies will not be stopped, but they don't live forever, and so in this problem, our aim is to expand Fibonacci's rabbit population model to allow for mortal rabbits.

*/

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