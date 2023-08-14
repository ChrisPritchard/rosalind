
// let input = """
// 10
// 1 2
// 2 8
// 4 10
// 5 9
// 6 10
// 7 9
// """
let input = System.IO.File.ReadAllText "./input.txt"

let parsed = input.Split ("\r\n".ToCharArray (), System.StringSplitOptions.RemoveEmptyEntries)
let minTotal = int parsed.[0] - 1
let existing = parsed.[1..].Length

let result = minTotal - existing
printfn "Result: %A" result

// credit to http://garyforbis.blogspot.com/2013/07/completing-my-32nd-problem-on-rosalind.html for helping me pull my head out of my ass