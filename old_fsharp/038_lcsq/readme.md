# Finding a Shared Spliced Motif

Link: [http://rosalind.info/problems/lcsq/](http://rosalind.info/problems/lcsq/)

## Background: Locating Motifs Despite Introns

In “Finding a Shared Motif”, we discussed searching through a database containing multiple genetic strings to find a longest common substring of these strings, which served as a motif shared by the two strings. However, as we saw in “RNA Splicing”, coding regions of DNA are often interspersed by introns that do not code for proteins.

We therefore need to locate shared motifs that are separated across exons, which means that the motifs are not required to be contiguous. To model this situation, we need to enlist subsequences.

## Problem

A string u is a common subsequence of strings s and t if the symbols of u appear in order as a subsequence of both s and t. For example, "ACTG" is a common subsequence of "AACCTTGG" and "ACACTGTGA".

Analogously to the definition of longest common substring, u is a longest common subsequence of s and t if there does not exist a longer common subsequence of the two strings. Continuing our above example, "ACCTTG" is a longest common subsequence of "AACCTTGG" and "ACACTGTGA", as is "AACTGG".

Given: Two DNA strings s and t (each having length at most 1 kbp) in FASTA format.

Return: A longest common subsequence of s and t. (If more than one solution exists, you may return any one.)

## Sample Dataset

```
>Rosalind_23
AACCTTGG
>Rosalind_64
ACACTGTGA
```

## Sample Output

```
AACTGG
```