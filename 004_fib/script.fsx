
let m, k = 35, 4L

let rec advanceMonth conceived newBorn reproductive n =
    let newReproductive = reproductive + newBorn
    if n = 1 then newReproductive 
    else 
        let newConceived = newReproductive * k
        let newBorn = conceived
        advanceMonth newConceived newBorn newReproductive (n - 1)

advanceMonth 0L 1L 0L m