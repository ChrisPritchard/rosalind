# Enumerating Oriented Gene Orderings

Link: [http://rosalind.info/problems/sign/](http://rosalind.info/problems/sign/)

## Background: Synteny Blocks Have Orientations

In “Enumerating Gene Orders”, we introduced synteny blocks for two different species, which are very similar areas of two species genomes that have been flipped and moved around by rearrangements. In that problem, we used the permutation to model the order of synteny blocks on a single chromosome.

However, each strand of a DNA molecule has an orientation (as RNA transcription only occurs in one direction), and so to more prudently model chromosomes using synteny blocks, we should provide each block with an orientation to indicate the strand on which it is located. Adding orientations to synteny blocks requires us to expand our notion of permutation so that each index in the permutation has its own orientation.

## Problem

A signed permutation of length n is some ordering of the positive integers {1,2,…,n} in which each integer is then provided with either a positive or negative sign (for the sake of simplicity, we omit the positive sign). For example, π=(5,−3,−2,1,4) is a signed permutation of length 5.

Given: A positive integer n≤6.

Return: The total number of signed permutations of length n, followed by a list of all such permutations (you may list the signed permutations in any order).