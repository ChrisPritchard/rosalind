# Counting Phylogenetic Ancestors

Link: [http://rosalind.info/problems/inod/](http://rosalind.info/problems/inod/)

## Background: Culling the Forest

In “Completing a Tree”, we introduced the tree for the purposes of constructing phylogenies. Yet the definition of tree as a connected graph with no cycles produces a huge class of different graphs, from simple paths and star-like graphs to more familiar arboreal structures (see Figure 1). Which of these graphs are appropriate for phylogenetic study?

Modern evolutionary theory (beginning with Darwin) indicates that a common way for a new species can be created is when it splits off from an existing species after a population is isolated for an extended period of time. This model of species evolution implies a very specific type of phylogeny, in which internal nodes represent branching points of evolution where an ancestor species either evolved into a new species or split into two new species: therefore, one edge of this internal node connects the node to its most recent ancestor, whereas one or two new edges connect it to its immediate descendants. This framework offers a much clearer notion of how to characterize phylogenies.

## Problem

A binary tree is a tree in which each node has degree equal to at most 3. The binary tree will be our main tool in the construction of phylogenies.

A rooted tree is a tree in which one node (the root) is set aside to serve as the pinnacle of the tree. A standard graph theory exercise is to verify that for any two nodes of a tree, exactly one path connects the nodes. In a rooted tree, every node v will therefore have a single parent, or the unique node w such that the path from v to the root contains {v,w}. Any other node x adjacent to v is called a child of v because v must be the parent of x; note that a node may have multiple children. In other words, a rooted tree possesses an ordered hierarchy from the root down to its leaves, and as a result, we may often view a rooted tree with undirected edges as a directed graph in which each edge is oriented from parent to child. We should already be familiar with this idea; it's how the Rosalind problem tree works!

Even though a binary tree can include nodes having degree 2, an unrooted binary tree is defined more specifically: all internal nodes have degree 3. In turn, a rooted binary tree is such that only the root has degree 2 (all other internal nodes have degree 3).

Given: A positive integer n (3≤n≤10000).

Return: The number of internal nodes of any unrooted binary tree having n leaves.

## Sample Dataset

```
4
```

## Sample Output

```
2
```

## Hint

In solving “Completing a Tree”, you may have formed the conjecture that a graph with no cycles and n nodes is a tree precisely when it has n−1 edges. This is indeed a theorem of graph theory.