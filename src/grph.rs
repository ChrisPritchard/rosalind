/*
A Brief Introduction to Graph Theory

Networks arise everywhere in the practical world, especially in biology. Networks are prevalent in popular applications such as modeling the spread of disease, but the extent of network applications spreads far beyond popular science. Our first question asks how to computationally model a network without actually needing to render a picture of the network.

First, some terminology: graph is the technical term for a network; a graph is made up of hubs called nodes (or vertices), pairs of which are connected via segments/curves called edges. If an edge connects nodes v
and w, then it is denoted by v,w (or equivalently w,v

).

    an edge v,w

is incident to nodes v and w; we say that v and w
are adjacent to each other;
the degree of v
is the number of edges incident to it;
a walk is an ordered collection of edges for which the ending node of one edge is the starting node of the next (e.g., {v1,v2}
, {v2,v3}, {v3,v4}

    , etc.);
    a path is a walk in which every node appears in at most two edges;
    path length is the number of edges in the path;
    a cycle is a path whose final node is equal to its first node (so that every node is incident to exactly two edges in the cycle); and
    the distance between two vertices is the length of the shortest path connecting them.

Graph theory is the abstract mathematical study of graphs and their properties.
*/

use crate::util;

const DATASET: &str = include_str!("../datasets/grph.txt");

const OVERLAP: usize = 3;

pub fn solve() {
    // this is actually not too difficult - its all matching adjacencies, not trying to get a unique loop (which would require a BFS approach)

    let fasta = util::read_fasta(DATASET);
    let nodes: Vec<_> = fasta.iter().map(|(label, sequence)| (label, sequence[0..OVERLAP].to_string(), sequence[sequence.len()-OVERLAP..].to_string())).collect();

    let mut result = Vec::new();
    nodes.iter().for_each(|(label, _, end)| {
        let adjacencies: Vec<_> = nodes.iter().filter(|(other, start, _)| other != label && start == end).map(|(other, _, _)| (label.to_string(), other.to_string())).collect();
        result.extend(adjacencies);
    });

    for (first, second) in result {
        println!("{first} {second}")
    }
}