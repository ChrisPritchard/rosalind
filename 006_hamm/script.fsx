
let input = [|
    "CCCCATACGAAGAATCGTAAGTGGGACAACAAAATCCCGTCTGAAATGCAGGGCTGATAACCGAGTAGTAACCATCTCGGAAAAGTAACTTCATTAGATTTCGCTTACTCTGGCATTACCATCAATCAGCTGGAGGCCGCGGGTCTGAGCCGTTGGAACCATGAAATACACAATTCCACTGGTCCTACATTCACCATGGGTAAGCAAGCCCGAAACTGGTCCGGTCTGGGGACCACCTAGATTGAATAGCTACTCTCTCGGACGACATGCTACGATTTAGGAGGCGGGATGACTATTTAGCGTCTATACACTAATGGTTATACAACGCCGAAGACCAATCCCAGAGAGACGAGATGAAGGGGGCGGAAGGAACACGACCGTAGTCGGCCCTCAGGCTGTGCTTGGCTTCCTATGCCGGAAAAAAACCTATTGCCAAGGCCGATTTCTACGTCGATCTGACCAGGCAATGGGATTGAGATACCCACGAACGCCGCGGGTCATCATTCCAGGAAGAGCTCACTTCTTCGTTTGTGGTCGGCTAACTCCTTTTCACTATCGGACGTCAGTCGGGGGTACCTCCCTTCTGGGTAGCCTACAGAGTCTGCATTACATCGCACCGAGCTTTAATTGGTGCGTTACTAGGCTTTGGCTCAGGGCCCGCCGAGCGAAATAGAAATTAGGTCTTGGACATCAGTGGCCTGTGATTAGACCCGATACCGCGTAAAATTGCGGTCTACCCCTTGCCTTTCTAATCATTATATAAGTCCTGTGTACATATGATGGCGTTCCACGTAGTATCTGTAAAAGCGACGAGTTCCGCTCCGGGTCGTAGCCCCCTGGGTCGTGGCCATTCTTAGGTGAATGGGACGTTCTTTAGGCCGTGTACGGTGCCGGTTCGTATAGACGGCAAACATTTCTCATTAATATAGACGTAGCTCTGGTTATTCTTATGGCCAGATTGATAATTGTTCTGACGAGGGCACAG"
    "GCCATCAGGACGAGTTCAGGGTGGGATGGCGATATCGTGTCGAAAAGGTAGTGCAGGTGGTCGAGTAATATCAATCTCTGACGTCGAACCCTAGTAGTGAGAGGCTTTCTTTGGATACACAACACTCGTATTGAACCCGTGGGCCTGAGCGTATCAGCTGTCGACAGACACACATTTCCCTATCCTTCAGACGCCAACGGGACCCATTAGCGAAAACCATAAAATTGACGCAAGTGGACGCTTGAGGGCCAAGTCAGTGCTTAGGTATGCTTGAAATCCTAACGCCCGCTCCATAATTCCCGCCTATAGACCAACCGTCTTCCCCTTCCAAAATGCTTCCCGGTCAGGAACAGCTGAATTGGTTCGTGGGCACACGACCTAGGTCTGCCCCGAGGACGTGCTTGGATACCTAGACTAGCCACAGCCCAGCTCTCAGAGGCGCGTCTCATGACGTTCAAATCTCTCCCTGCCATTTGTATGCCCCCGTTTGGGCCGACTTCGCTATCCTGGAACTGCCCACTGTTGCAATCCCTGTCTGCGAATGCGTTGACTTCGGCCGTATGCGGAGGGGGCTGCCGCCCTTCTGTGGCGTGGAGTTCGGCACCATGTCTGCTGGTTAAAGTCAACGGAGAGTTCCTCTAGGGTCTCGGCCGATGCGACCGTTGCGGGATCGTCTCCAATTCTGCGGCCTAAGTTCCCTGAGATGAAAACTGCTATAGTGTACACTGTTTGTCTGCCCCTTTACTCTATATTTTGCAGCTCAGTACTAAGCACATTCAACGGCGGTCCCCCACGAAGTTGTATTAGCATCTGGGTGGCTAATCTCGGTATGCCGGCTCGGTTGTTGGCGGAGAAAAGAGAAAGTGACATACAGGACGACGTTTTGAGCGCTGGCTCATATATAGAACATATTTTGGTCTTTAATCTATACTCAACTAGGGCCATACATATGGACCGCGTGCGGCGTGTGCCGACGAGGGGAGCT"
|]

Seq.zip input.[0] input.[1] |> Seq.filter (fun (a, b) -> a <> b) |> Seq.length