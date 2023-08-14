# Finding a Spliced Motif

Link: [http://rosalind.info/problems/sseq/](http://rosalind.info/problems/sseq/)

## Background: Motifs Are Rarely Contiguous

In “Finding a Motif in DNA”, we searched for occurrences of a motif as a substring of a larger database genetic string. However, because a DNA strand coding for a protein is often interspersed with introns (see “RNA Splicing”), we need a way to recognize a motif that has been chopped up into pieces along a chromosome.

## Problem

A subsequence of a string is a collection of symbols contained in order (though not necessarily contiguously) in the string (e.g., ACG is a subsequence of TATGCTAAGATC). The indices of a subsequence are the positions in the string at which the symbols of the subsequence appear; thus, the indices of ACG in TATGCTAAGATC can be represented by (2, 5, 9).

As a substring can have multiple locations, a subsequence can have multiple collections of indices, and the same index can be reused in more than one appearance of the subsequence; for example, ACG is a subsequence of AACCGGTT in 8 different ways.

Given: Two DNA strings s and t (each of length at most 1 kbp) in FASTA format.

Return: One collection of indices of s in which the symbols of t appear as a subsequence of s. If multiple solutions exist, you may return any one.

## Extra Information

For the mathematically inclined, we may equivalently say that t=t1t2⋯tm is a subsequence of s=s1s2⋯sn if the characters of t appear in the same order within s. Even more formally, a subsequence of s is a string si1si2…sik, where 1≤i1<i2⋯<ik≤n.

## Sample Dataset

```
>Rosalind_14
ACGTACGTGACG
>Rosalind_18
GTA
```

## Sample Output

```
3 8 10
```