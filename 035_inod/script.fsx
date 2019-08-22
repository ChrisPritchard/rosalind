
let input = 5

let rec internals connectedTo sum =
    if connectedTo < 3 then sum
    else
        let nodes = int (floor (float connectedTo / 2.))
        internals nodes (sum + nodes)

let result = internals input 0
printfn "Result: %i" result