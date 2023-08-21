/*

    The Need for Averages

    Averages arise everywhere. In sports, we want to project the average number of games that a team is expected to win; in gambling, we want to project the average losses incurred playing blackjack; in business, companies want to calculate their average expected sales for the next quarter.

    Molecular biology is not immune from the need for averages. Researchers need to predict the expected number of antibiotic-resistant pathogenic bacteria in a future outbreak, estimate the predicted number of locations in the genome that will match a given motif, and study the distribution of alleles throughout an evolving population. In this problem, we will begin discussing the third issue; first, we need to have a better understanding of what it means to average a random process.

*/

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