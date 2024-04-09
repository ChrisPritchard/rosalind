use std::env;


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
mod lia;
mod mprt;
mod mrna;
mod orf;

fn main() {
    let token = env::args().nth(1).unwrap_or(String::from("")).to_lowercase();
    match token.as_str() {
        "dna"   => dna::solve(),
        "rna"   => rna::solve(),
        "revc"  => revc::solve(),
        "fib"   => fib::solve(),
        "gc"    => gc::solve(),
        "hamm"  => hamm::solve(),
        "iprb"  => iprb::solve(),
        "prot"  => prot::solve(),
        "subs"  => subs::solve(),
        "cons"  => cons::solve(),
        "fibd"  => fibd::solve(),
        "grph"  => grph::solve(),
        "iev"   => iev::solve(),
        "lcsm"  => lcsm::solve(),
        "lia"   => lia::solve(),
        "mprt"  => mprt::solve(),
        "mrna"  => mrna::solve(),
        "orf" | _ => orf::solve(),
    }
}
