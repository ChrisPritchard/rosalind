# Completing a Tree

Link: [http://rosalind.info/problems/tree/](http://rosalind.info/problems/tree/)

## Background: The Tree of Life

"As buds give rise by growth to fresh buds, and these, if vigorous, branch out and overtop on all sides many a feebler branch, so by generation I believe it has been with the great Tree of Life, which fills with its dead and broken branches the crust of the earth, and covers the surface with its ever-branching and beautiful ramifications." Charles Darwin, The Origin of Species

A century and a half has passed since the publication of Darwin's magnum opus, and yet the construction of a single Tree of Life uniting life on Earth still has not been completed, with perhaps as many as 90% of all living species not yet catalogued (although a beautiful interactive animation has been produced by OneZoom).

To learn about state-of-the-art attempts to build the Tree of Life, you may like to check out the Tree of Life Web Project, a collaborative effort by biologists from around the world. This peer-reviewed project started in 1995, and today it has grown to contain more than 10,000 pages with characteristics of different groups of organisms and their evolutionary history.

Instead of trying to construct the entire Tree of Life all at once, we often wish to form a simpler tree in which a collection of species have been clumped together for the sake of simplicity; such a group is called a taxon (pl. taxa). For a given collection of taxa, a phylogeny is a treelike diagram that best represents the evolutionary connections between the taxa: the construction of a particular phylogeny depends on our specific assumptions regarding how these evolutionary relationships should be interpreted. See Figure 1.

## Problem

An undirected graph is connected if there is a path connecting any two nodes. A tree is a connected (undirected) graph containing no cycles; this definition forces the tree to have a branching structure organized around a central core of nodes, just like its living counterpart. See Figure 2.

We have already grown familiar with trees in “Mendel's First Law”, where we introduced the probability tree diagram to visualize the outcomes of a random variable.

In the creation of a phylogeny, taxa are encoded by the tree's leaves, or nodes having degree 1. A node of a tree having degree larger than 1 is called an internal node.

Given: A positive integer n (n≤1000) and an adjacency list corresponding to a graph on n nodes that contains no cycles.

Return: The minimum number of edges that can be added to the graph to produce a tree.