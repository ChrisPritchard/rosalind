use crate::util::{SuffixNode, longest_common_substring};

mod util;

mod dna;
mod rna;
mod revc;
mod fib;
mod gc;
mod hamm;
mod iprb;
mod prot;
mod subs;
mod cons;
mod fibd;
mod grph;
mod iev;
mod lcsm;

fn main() {
    println!("problem solutions, labelled by their problem code:");

    print!("\nDNA:\n");
    dna::solve();

    print!("\nRNA:\n");
    rna::solve();

    print!("\nREVC:\n");
    revc::solve();

    print!("\nFIB:\n");
    fib::solve();

    print!("\nGC:\n");
    gc::solve();

    print!("\nHAMM:\n");
    hamm::solve();

    print!("\nIPRB:\n");
    iprb::solve();

    print!("\nPROT:\n");
    prot::solve();

    print!("\nSUBS:\n");
    subs::solve();

    print!("\nCONS:\n");
    cons::solve();

    print!("\nFIBD:\n");
    fibd::solve();

    print!("\nGRPH:\n");
    grph::solve();

    print!("\nIEV:\n");
    iev::solve();

    print!("\nLCSM:\n");
    lcsm::solve();

    // let mut root = SuffixNode::new(1);
    // util::general_suffix_tree(&mut root, "GATTACA".to_string(), 1);
    // util::general_suffix_tree(&mut root, "TAGACCA".to_string(), 2);
    // util::general_suffix_tree(&mut root, "ATACA".to_string(), 3);
    // println!("{}", longest_common_substring(&root, 3));
}
