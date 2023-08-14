
mod dna;
mod rna;
mod revc;

fn main() {
    println!("problem solutions, labelled by their problem code:");

    print!("\nDNA:\n\t");
    dna::solve();

    print!("\nRNA:\n\t");
    rna::solve();

    print!("\nREVC:\n\t");
    revc::solve();
}
