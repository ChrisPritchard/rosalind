
//let k, m, n = 2, 2, 2
let k, m, n = 15, 23, 21

let pop = (k + m + n) * (k + m + n - 1)

let fk, fm, fn = float k, float m, float n
let success = 
        (fk * (fk-1.)) + (fk * fm) + (fk * fn)
        + (fm * fk) + (fm * (fm-1.) * 0.75) + (fm * fn * 0.5)
        + (fn * fk) + ((fn * fm) * 0.5)
let result = success / float pop

printfn "Result: %f" result