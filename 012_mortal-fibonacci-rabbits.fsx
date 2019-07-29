
(*
Mortal Fibonacci Rabbits:

In “Rabbits and Recurrence Relations”, we mentioned the disaster caused by introducing European rabbits into Australia. By the turn of the 20th Century, the situation was so out of control that the creatures could not be killed fast enough to slow their spread (see Figure 1).

The conclusion? Build a fence! The fence, intended to preserve the sanctity of Western Australia, was completed in 1907 after undergoing revisions to push it back as the bunnies pushed their frontier ever westward (see Figure 2). If it sounds like a crazy plan, the Australians at the time seem to have concurred, as shown by the cartoon in Figure 3.

By 1950, Australian rabbits numbered 600 million, causing the government to decide to release a virus (called myxoma) into the wild, which cut down the rabbits until they acquired resistance. In a final Hollywood twist, another experimental rabbit virus escaped in 1991, and some resistance has already been observed.

The bunnies will not be stopped, but they don't live forever, and so in this problem, our aim is to expand Fibonacci's rabbit population model to allow for mortal rabbits.
*)

let n, m = 95, 17

let rec advanceMonth conceived newBorn reproductive n =
    if n = 1 then 
        List.sumBy fst reproductive + newBorn
    else
        let aged = reproductive |> List.filter (fun (_,a) -> a < m) |> List.map (fun (c, a) -> (c, a + 1))
        let newReproductive = (newBorn,2)::aged
        let newConceived = newReproductive |> List.sumBy (fun (c, _) -> c)
        let newNewBorn = conceived
        advanceMonth newConceived newNewBorn newReproductive (n - 1)

advanceMonth 0L 1L [] n