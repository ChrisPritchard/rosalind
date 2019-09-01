# Edit Distance

Link: [http://rosalind.info/problems/edit/](http://rosalind.info/problems/edit/)

## Background: Point Mutations Include Insertions and Deletions

In “Counting Point Mutations”, we saw that Hamming distance gave us a preliminary notion of the evolutionary distance between two DNA strings by counting the minimum number of single nucleotide substitutions that could have occurred on the evolutionary path between the two strands.

However, in practice, homologous strands of DNA or protein are rarely the same length because point mutations also include the insertion or deletion of a single nucleotide (and single amino acids can be inserted or deleted from peptides). Thus, we need to incorporate these insertions and deletions into the calculation of the minimum number of point mutations between two strings. One of the simplest models charges a unit "cost" to any single-symbol insertion/deletion, then (in keeping with parsimony) requests the minimum cost over all transformations of one genetic string into another by point substitutions, insertions, and deletions.

## Problem

Given two strings s and t (of possibly different lengths), the edit distance dE(s,t) is the minimum number of edit operations needed to transform s into t, where an edit operation is defined as the substitution, insertion, or deletion of a single symbol.

The latter two operations incorporate the case in which a contiguous interval is inserted into or deleted from a string; such an interval is called a gap. For the purposes of this problem, the insertion or deletion of a gap of length k still counts as k distinct edit operations.

Given: Two protein strings s and t in FASTA format (each of length at most 1000 aa).

Return: The edit distance dE(s,t).

## Sample Dataset

```
>Rosalind_39
PLEASANTLY
>Rosalind_11
MEANLY
```

## Sample Output

```
5
```