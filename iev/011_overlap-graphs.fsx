(*
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
*)

open System.IO
#load "./fasta.fs"

let s = File.ReadAllText "./011_input.txt"
let o = File.OpenWrite "./011_output.txt"
let w = new StreamWriter(o)

let fasta = Fasta.parse s
for (name, dna) in fasta do
    let suffix = dna.[dna.Length-3..]
    fasta 
    |> List.filter (fun (n, d) -> n <> name && d.[0..2] = suffix)
    |> List.iter (fun (other, _) -> w.WriteLine(sprintf "%s %s" name other))

w.Close ()
w.Dispose ()
