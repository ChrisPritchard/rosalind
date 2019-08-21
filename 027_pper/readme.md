# Partial Permutations

Link: [http://rosalind.info/problems/pper/](http://rosalind.info/problems/pper/)

## Background: Partial Gene Orderings

Similar species will share many of the same genes, possibly with modifications. Thus, we can compare two genomes by analyzing the orderings of their genes, then inferring which rearrangements have separated the genes.

In “Enumerating Gene Orders”, we used permutations to model gene orderings. Yet two genomes will have evolved along their own separate paths, and so they won't share all of the same genes. As a result, we should modify the notion of permutation in order to quantify the notion of partial gene orderings.

## Problem

A partial permutation is an ordering of only k objects taken from a collection containing n objects (i.e., k≤n). For example, one partial permutation of three of the first eight positive integers is given by (5,7,2).

The statistic P(n,k) counts the total number of partial permutations of k objects that can be formed from a collection of n objects. Note that P(n,n) is just the number of permutations of n objects, which we found to be equal to n!=n(n−1)(n−2)⋯(3)(2) in “Enumerating Gene Orders”.

Given: Positive integers n and k such that 100≥n>0 and 10≥k>0.

Return: The total number of partial permutations P(n,k), modulo 1,000,000.

Sample Dataset

```
21 7
```

Sample Output

```
51200
```