
// this script uses .NETs BigInteger (bigint in F#). It allows an arbitarily large number to be represented. 
// i.e. I don't need to mod by 1 mil here, technically, if I wanted the raw number. It's 430 digits long.

#load "../codons.fs"

//let input = "MA"
let input = "MDCVGMTHQMTYNSANFSVLKEGWCLITCGVLESIMERGKKLENNRQDMTKDNSTFIEKQKWMLGFIVRCRCQHKQFHEDSKKFYFGSCWTAMRMDTPTPEGVLYCCMIKEMMMAKRDYYSSTRCATGVDWLSDRQCCREKCVMTITVWLRFLQVSHLWDYKYQVCWTILEYVFWTDTAVFGDWRGGGDNGTAYLDEVNCSHEKSATHKICAGFPQRSSEVGQIMMYVMNVTKHFTMRGQWMVEFMLCEWGKIPCQLQLHGMKMLILNLVVIRCWQIIMVEFRPMLVCSYQLNWGETYWPHIRLKRAEFIIWADISKPWIEGHRYPTRHRFAEKWQREFNPVFQDEINDWICPATFWEMDGKDHYNYYIQIHASPKHVKAEIQGVICPQAKDTCIVTKERGDGETAVQQNKQHTGLLWTCSNRVPFIVVMTCHLLFFCFLTRKCNWGGRRLICYWGHSPEVSSPLWQQQSTWFRLGVQYIMVDCHMQFPWRYPFMFHAEPSDYFKSTIYLWSLGMFPVPADRDYRQFVAYEPCGKIQEPTMMSPNCKIEETVHLKYNFEMKETMNYGIEARKRSQISGWVTTMRIYETISLEDEPCGVKFQQVHGWCFTQSIHGDWNAHWWHEGPEALRALNIDGACKKDDGLGLKEETTVIPQHHKQVSDFESYHKDSQPQPVTFWVAKPPHSLMLAGYHREQTNGVDEDFGETGFYWKVRVSYMDIHGFMMRMVGMTKHDQMVMDMCVQYVKLPPMFWWKVAENSCMGTPDDGGDLMMISSGRPRAEARHNKVVMVDKYRRITNVCSREQDWDTIGPQQALQPLRFDCVISVHRKSSLLCWYREDRKKKHSGVGKFDFQSRDWYPQQWSVTKVLAYKTMKYGPMRYEIQMCFVGMMMAAMWFDYRHWGTYMLNQAKKQACSPCKVMSMEQEIFYRNGVYFETAWMNNMVSAYTTWFTLAVLITVCDFKTAWYCDEYTGGIYMKDWRDGWTNIRIMDSKFVESTSME"

let counts = 
    Codons.table 
    |> Map.toArray 
    |> Array.groupBy snd 
    |> Array.filter (fst >> (<>) "Stop") 
    |> Array.map (fun (key, codons) -> char key, bigint codons.Length) 
    |> Map.ofArray

let result = (bigint 3, input) ||> Seq.fold (fun total c -> total * counts.[c])
let mod1mil = result % bigint 1000000

printfn "result: %A" mod1mil