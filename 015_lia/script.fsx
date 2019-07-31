
// this is a binomial distribution problem. so first need to get probability at generation k that a given organism will be Aa Ba
// for Aa Ba + Aa Ba the probability of an Aa Ba child is 0.25 (prob of Aa is 0.5 and prob of Ba is 05, so both is 0.25)
// so...at a guess, 0.25^k?

// then binomial formula: (n k) * p^k * (1 - p)^n-k. in this instance, at the kth generation there will be 2^(k-1) children, which is n in formula. and N is the k value.
// so for sample of 2, there is 2 children. (n k) = n! / k! * (n - k)!, so from 2 choose 1 is 2 / 1 * 1 = 2. 2 * 0.0625 * 0.9375

let k, N = 2, 1

