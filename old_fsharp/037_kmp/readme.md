# Speeding Up Motif Finding

Link: [http://rosalind.info/problems/kmp/](http://rosalind.info/problems/kmp/)

## Background: Shortening the Motif Search

In “Finding a Motif in DNA”, we discussed the problem of searching a genome for a known motif. Because of the large scale of eukaryotic genomes, we need to accomplish this computational task as efficiently as possible.

The standard method for locating one string t as a substring of another string s (and perhaps one you implemented in “Finding a Motif in DNA”) is to move a sliding window across the larger string, at each step starting at s[k] and matching subsequent symbols of t to symbols of s. After we have located a match or mismatch, we then shift the window backwards to begin searching at s[k+1].

The potential weakness of this method is as follows: say we have matched 100 symbols of t to s before reaching a mismatch. The window-sliding method would then move back 99 symbols of s and start comparing t to s; can we avoid some of this sliding?

For example, say that we are looking for t=ACGTACGT in s=TAGGTACGTACGGCATCACG. From s[6] to s[12], we have matched seven symbols of t, and yet s[13] = G produces a mismatch with t[8] = T. We don't need to go all the way back to s[7] and start matching with t because s[7]=C, s[8]=G, and s[9]=T are all different from t[1]=A. What about s[10]? Because t[1:4]=t[5:8]=ACGT, the previous mismatch of s[13]=G and t[8]=T guarantees the same mismatch with s[13] and t[4]. Following this analysis, we may advance directly to s[14] and continue sliding our window, without ever having to move it backward.

This method can be generalized to form the framework behind the Knuth-Morris-Pratt algorithm (KMP), which was published in 1977 and offers an efficiency boost for determining whether a given motif can be located within a larger string.

## Problem

A prefix of a length n string s is a substring s[1:j]; a suffix of s is a substring s[k:n].

The failure array of s is an array P of length n for which P[k] is the length of the longest substring s[j:k] that is equal to some prefix s[1:k−j+1], where j cannot equal 1 (otherwise, P[k] would always equal k). By convention, P[1]=0.

Given: A DNA string s (of length at most 100 kbp) in FASTA format.

Return: The failure array of s.

## Sample Dataset

```
>Rosalind_87
CAGCATGGTATCACAGCAGAG
```

## Sample Output

```
0 0 0 1 2 0 0 0 0 0 0 1 2 1 2 3 4 5 3 0 0
```

## Extra Information

If you would like a more precise technical explanation of the Knuth-Morris-Pratt algorithm, please take a look at this site: http://www.inf.fh-flensburg.de/lang/algorithmen/pattern/kmpen.htm