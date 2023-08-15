
mod dna;
mod rna;
mod revc;
mod fib;
mod gc;
mod hamm;

fn main() {
    println!("problem solutions, labelled by their problem code:");

    print!("\nDNA:\n\t");
    dna::solve();

    print!("\nRNA:\n\t");
    rna::solve();

    print!("\nREVC:\n\t");
    revc::solve();

    print!("\nFIB:\n\t");
    fib::solve();

    print!("\nGC:\n\t");
    gc::solve();

    print!("\nHAMM:\n\t");
    hamm::solve();
}
