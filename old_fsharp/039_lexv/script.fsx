
// let input = """
// D N A
// 3
// """
let input = """
V R M N O P E Z B D
4
"""

let alphabet, maxLen = 
    input.Split ("\r\n".ToCharArray(), System.StringSplitOptions.RemoveEmptyEntries)
    |> fun a -> a.[0].Split(' '), int a.[1]

let rec expander prefix = 
    [
        for c in alphabet do
            let res = prefix + c
            yield res
            if res.Length < maxLen then
                yield! expander res
    ]

let result = expander "" |> String.concat "\r\n"

System.IO.File.WriteAllText ("./output.txt", result)
printfn "Result written to output.txt"