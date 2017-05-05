module Contest
  
  let infiniteLine =
    Seq.initInfinite (fun x -> 8*x + 1 |> float |> sqrt |> int |> fun x -> (x - 1) / 2 + 1)
  //(https://www.wolframalpha.com/input/?i=(1+%2B+n)*n+%2F+2+%3D+k,+n+element+N)

  let printer n =
    let printLine n m =
      if n = m 
      then
        printf "*%s*\n" (String.replicate (m - 2) "*")
      else
        printf "*%s*\n" (String.replicate (m - 2) " ")

    let rec printRow n m =
      match n with
      | n when n = 1 -> 
        printLine m m
        printRow (n + 1) m
      | n when n = m ->
        printLine n n
      | _ ->
        printLine n m
        printRow (n + 1) m

    if n < 1
    then
      raise (System.ArgumentException("Negative arg to printer!"))
    else if n = 1
    then
      printf "*\n"
    else if n = 2
    then
      printf "**\n"
      printf "**\n"
    else
      printRow 1 n

  let rec insertIntoSortedList value l = 
    match l with
    | (x :: xs) -> (if x < value then (fun l -> x :: value :: l) else (fun l -> value :: x :: l)) <| xs
    | [] -> [value]

  let saveHead l =
    match l with
    | [] -> raise (System.Exception("Queue is empty!"))
    | _ -> l.Head

  let saveTail l =
    match l with
    | [] -> raise (System.Exception("Queue is empty!"))
    | _ -> l.Tail

  type PriorityQueue<'a when 'a: comparison>() = //'
    let mutable (l : List<'a>) = []
    member this.push value =
      l <- insertIntoSortedList value l

    member this.top = saveHead l
    member this.pop = 
      l <- saveTail l
