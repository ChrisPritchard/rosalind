
let input = """
D N A
3
"""
// let input = """
// D N A
// 3
// """

let alphabet = (input.Split ("\r\n".ToCharArray())).[0].Split(' ')

let result = ""

// printfn "%s" result

System.IO.File.WriteAllText ("./output.txt", result)
printfn "Result written to output.txt"