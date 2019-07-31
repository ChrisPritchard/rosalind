
(*
The need for averages:

Averages arise everywhere. In sports, we want to project the average number of games that a team is expected to win; in gambling, we want to project the average losses incurred playing blackjack; in business, companies want to calculate their average expected sales for the next quarter.

Molecular biology is not immune from the need for averages. Researchers need to predict the expected number of antibiotic-resistant pathogenic bacteria in a future outbreak, estimate the predicted number of locations in the genome that will match a given motif, and study the distribution of alleles throughout an evolving population. In this problem, we will begin discussing the third issue; first, we need to have a better understanding of what it means to average a random process.
*)

// calculating average a couple will have AT LEAST ONE is the same as 1. - NONE
// e.g. Aa - Aa, to pick 'a' twice is 0.5 * 0.5 = 0.25. So at least one 'A' is 1. - 0.25 = 0.75

let AaAa = 1. - (0.5 * 0.5)
let Aaaa = 1. - (0.5 * 1.)

let averages = [|1.;1.;1.;AaAa;Aaaa;0.|]
let counts = "17844 18985 17486 17782 16428 19215".Split(' ') |> Array.map float

let result = Array.zip averages counts |> Array.sumBy (fun (a, c) -> a * c * 2.)