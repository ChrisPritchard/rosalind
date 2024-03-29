/*
Mendel's Second Law
Figure 1. Mendel's second law dictates that every one of the 16 possible assignments of parental alleles is equally likely. The Punnett square for two factors therefore places each of these assignments in a cell of a 4 X 4 table. The probability of an offspring's genome is equal to the number of times it appears in the table, divided by 16.

Recall that Mendel's first law states that for any factor, an individual randomly assigns one of its two alleles to its offspring. Yet this law does not state anything regarding the relationship with which alleles for different factors will be inherited.

After recording the results of crossing thousands of pea plants for seven years, Mendel surmised that alleles for different factors are inherited with no dependence on each other. This statement has become his second law, also known as the law of independent assortment.

What does it mean for factors to be "assorted independently?" If we cross two organisms, then a shortened form of independent assortment states that if we look only at organisms having the same alleles for one factor, then the inheritance of another factor should not change.

For example, Mendel's first law states that if we cross two Aa
organisms, then 1/4 of their offspring will be aa, 1/4 will be AA, and 1/2 will be Aa. Now, say that we cross plants that are both heterozygous for two factors, so that both of their genotypes may be written as Aa Bb. Next, examine only Bb offspring: Mendel's second law states that the same proportions of AA, Aa, and aa individuals will be observed in these offspring. The same fact holds for BB and bb

offspring.

As a result, independence will allow us to say that the probability of an aa BB
offspring is simply equal to the probability of an aa offspring times the probability of a BB

organism, i.e., 1/16.

Because of independence, we can also extend the idea of Punnett squares to multiple factors, as shown in Figure 1. We now wish to quantify Mendel's notion of independence using probability.
*/

use std::collections::HashMap;

use num_bigint::{BigUint, ToBigUint};

const K: u32 = 6;
const N: u32 = 17;

fn fact(n: u32, mem: &mut HashMap<u32, BigUint>) -> BigUint {
    if n == 1 || n == 0 {
        1.to_biguint().unwrap()
    } else if mem.contains_key(&n) {
        mem[&n].clone()
    } else {
        let res = n * fact(n-1, mem);
        mem.insert(n, res.clone());
        res
    }
}


fn binomial_coefficient(n: u32, r: u32, mem: &mut HashMap<u32, BigUint>) -> u {
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

        println!("{}", possible_ways_to_get_r);
        
        total_prob += prob_of_r_target * prob_of_n_minus_r_not_target;
    }

    println!("{:.3}", total_prob);
}