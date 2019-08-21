# Transitions and Transversions

Link: [http://rosalind.info/problems/tran/](http://rosalind.info/problems/tran/)

## Background: Certain Point Mutations are More Common

Point mutations occurring in DNA can be divided into two types: transitions and transversions. A transition substitutes one purine for another (A↔G) or one pyrimidine for another (C↔T); that is, a transition does not change the structure of the nucleobase. Conversely, a transversion is the interchange of a purine for a pyrimidine base, or vice-versa. See Figure 1. Transitions and transversions can be defined analogously for RNA mutations.

Because transversions require a more drastic change to the base's chemical structure, they are less common than transitions. Across the entire genome, the ratio of transitions to transversions is on average about 2. However, in coding regions, this ratio is typically higher (often exceeding 3) because a transition appearing in coding regions happens to be less likely to change the encoded amino acid, particularly when the substituted base is the third member of a codon (feel free to verify this fact using the DNA codon table). Such a substitution, in which the organism's protein makeup is unaffected, is known as a silent substitution.

Because of its potential for identifying coding DNA, the ratio of transitions to transversions between two strands of DNA offers a quick and useful statistic for analyzing genomes.

## Problem

For DNA strings s1 and s2 having the same length, their transition/transversion ratio R(s1,s2) is the ratio of the total number of transitions to the total number of transversions, where symbol substitutions are inferred from mismatched corresponding symbols as when calculating Hamming distance (see “Counting Point Mutations”).

Given: Two DNA strings s1 and s2 of equal length (at most 1 kbp).

Return: The transition/transversion ratio R(s1,s2).

## Sample Dataset

```
>Rosalind_0209
GCAACGCACAACGAAAACCCTTAGGGACTGGATTATTTCGTGATCGTTGTAGTTATTGGA
AGTACGGGCATCAACCCAGTT
>Rosalind_2200
TTATCTGACAAAGAAAGCCGTCAACGGCTGGATAATTTCGCGATCGTGCTGGTTACTGGC
GGTACGAGTGTTCCTTTGGGT
```

## Sample Output

```
1.21428571429
```