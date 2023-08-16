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
}
