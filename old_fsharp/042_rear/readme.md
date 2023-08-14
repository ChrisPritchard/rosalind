# Reversal Distance

Link: [http://rosalind.info/problems/mmch/](http://rosalind.info/problems/mmch/)

## Background: Rearrangements Power Large-Scale Genomic Changes

Perhaps the most common type of genome rearrangement is an inversion, which flips an entire interval of DNA found on the same chromosome. As in the case of calculating Hamming distance (see “Counting Point Mutations”), we would like to determine the minimum number of inversions that have occurred on the evolutionary path between two chromosomes. To do so, we will use the model introduced in “Enumerating Gene Orders” in which a chromosome is represented by a permutation of its synteny blocks.

## Problem

A reversal of a permutation creates a new permutation by inverting some interval of the permutation; (5,2,3,1,4), (5,3,4,1,2), and (4,1,2,3,5) are all reversals of (5,3,2,1,4). The reversal distance between two permutations π and σ, written drev(π,σ), is the minimum number of reversals required to transform π into σ (this assumes that π and σ have the same length).

Given: A collection of at most 5 pairs of permutations, all of which have length 10.

Return: The reversal distance between each permutation pair.

## Sample Dataset

```
1 2 3 4 5 6 7 8 9 10
3 1 5 2 7 4 9 6 10 8

3 10 8 2 5 4 7 1 6 9
5 2 3 1 7 4 10 8 6 9

8 6 7 9 4 1 3 10 2 5
8 2 7 6 9 1 5 3 10 4

3 9 10 4 1 8 6 7 5 2
2 9 8 5 1 7 3 4 6 10

1 2 3 4 5 6 7 8 9 10
1 2 3 4 5 6 7 8 9 10
```

## Sample Output

```
9 4 5 7 0
```

## Hint

Don't be afraid to try an ugly solution.