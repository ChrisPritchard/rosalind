/*

    Finding a Most Likely Common Ancestor

    In “Counting Point Mutations”, we calculated the minimum number of symbol mismatches between two strings of equal length to model the problem of finding the minimum number of point mutations occurring on the evolutionary path between two homologous strands of DNA. If we instead have several homologous strands that we wish to analyze simultaneously, then the natural problem is to find an average-case strand to represent the most likely common ancestor of the given strands.
 */

use std::collections::HashMap;

use crate::util;

const DATASET: &str = include_str!("../datasets/cons.txt");

pub fn solve() {

}