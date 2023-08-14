
// let input = """
// A2Z669
// B5ZC00
// P07204_TRBM_HUMAN
// P20840_SAG1_YEAST
// """
let input = """
P02748_CO9_HUMAN
P01876_ALC1_HUMAN
P47002
Q8ZRE7
P28314_PER_COPCI
P14210_HGF_HUMAN
P39873_RNBR_BOVIN
P35446_FSPO_RAT
P20840_SAG1_YEAST
A9M5H3
Q9HUU8
Q1JLH6
P04441_HG2A_MOUSE
P02725_GLP_PIG
"""

let split (s: string) = s.Split([|'\r';'\n'|], System.StringSplitOptions.RemoveEmptyEntries)
let ids = split input

let predicate (index, s: char []) = 
    // The rule is: N{P}[ST]{P}
    if s.[0] = 'N' && s.[1] <> 'P' && (s.[2] = 'S' || s.[2] = 'T') && s.[3] <> 'P' then Some (index + 1) else None

let indexesFor (fasta: string) = 
    fasta.ToCharArray () 
    |> Array.windowed 4 
    |> Array.indexed 
    |> Array.choose predicate

let fastaFor (id: string) = 
    let url = sprintf "http://www.uniprot.org/uniprot/%s.fasta" id
    let req = System.Net.HttpWebRequest.Create url :?> System.Net.HttpWebRequest
    let resp = req.GetResponse ()
    use stream = resp.GetResponseStream ()
    use reader = new System.IO.StreamReader (stream)
    reader.ReadToEnd () |> split |> Array.skip 1 |> String.concat ""

let result = 
    ids 
    |> Array.collect (fun id -> 
        let fasta = fastaFor id
        let indexes = indexesFor fasta
        if Array.isEmpty indexes then Array.empty
        else
            [|id;indexes |> Array.map string |> String.concat " "|])
    |> String.concat "\r\n"

printfn "%s" result