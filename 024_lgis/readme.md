# Longest Increasing Subsequence

Link: [http://rosalind.info/problems/lgis/](http://rosalind.info/problems/lgis/)

## Background: A Simple Measure of Gene Order Similarity

In “Enumerating Gene Orders”, we started talking about comparing the order of genes on a chromosome taken from two different species and moved around by rearrangements throughout the course of evolution.

One very simple way of comparing genes from two chromosomes is to search for the largest collection of genes that are found in the same order in both chromosomes. To do so, we will need to apply our idea of permutations. Say that two chromosomes share n
genes; if we label the genes of one chromosome by the numbers 1 through n in the order that they appear, then the second chromosome will be given by a permutation of these numbered genes. To find the largest number of genes appearing in the same order, we need only to find the largest collection of increasing elements in the permutation.

## Problem

A subsequence of a permutation is a collection of elements of the permutation in the order that they appear. For example, (5, 3, 4) is a subsequence of (5, 1, 3, 4, 2).

A subsequence is increasing if the elements of the subsequence increase, and decreasing if the elements decrease. For example, given the permutation (8, 2, 1, 6, 5, 7, 4, 3, 9), an increasing subsequence is (2, 6, 7, 9), and a decreasing subsequence is (8, 6, 5, 4, 3). You may verify that these two subsequences are as long as possible.

Given: A positive integer n≤10000 followed by a permutation π of length n.

Return: A longest increasing subsequence of π, followed by a longest decreasing subsequence of π.