module Func
  let evenList1 = List.filter (fun x -> (x % 2) = 0) >> List.length

  let evenList2 = List.fold (fun acc x -> (if (x % 2) = 0 then 1 else 0) + acc) 0

  let evenList3 = List.map (fun x -> if (x % 2) = 0 then 1 else 0) >> List.sum

  type Tree<'a> =
    | Empty
    | Node of 'a * Tree<'a> * Tree<'a>

  let rec treeMap f binTree =
    match binTree with
    | Node(x, l, r) -> Node(f x, treeMap f l, treeMap f r)
    | _ -> Empty

  type ArghTree =
    | Var of int
    | Plus of ArghTree * ArghTree
    | Subtract of ArghTree * ArghTree
    | Multiply of ArghTree * ArghTree
    | Divide of ArghTree * ArghTree

  let rec countB arghTree =
    match arghTree with
    | Var(a) -> a
    | Plus(a, b) -> (+) (countB a) (countB b)
    | Subtract(a, b) -> (-) (countB a) (countB b)
    | Multiply(a, b) -> (*) (countB a) (countB b)
    | Divide(a, b) -> (/) (countB a) (countB b)

  let seqPrime =
    Seq.initInfinite (fun x -> x) |> Seq.filter (fun x -> x > 1 && 0 = Seq.length (Seq.filter (fun y -> (x % y) = 0) [2..(x-1)]))