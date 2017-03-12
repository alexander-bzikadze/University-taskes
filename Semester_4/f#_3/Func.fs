module Func

// For ordered. I guess there is no way to do it not in O(n^2) without comparison as there is no order
let is_unique l = 
  let rec helper l = 
    match l with
      | x :: y :: xs -> if x = y then false else helper (y :: xs)
      | _ -> true
  helper (List.sort l) // tried >> but it went wrong as List.sort is generic. Aid?

let max_neighbour l = 
  let rec helper l acc =
    match l with
      | x :: y :: xs -> helper (y :: xs) (max acc (x + y))
      | _ -> Some(acc)
  match l with
    | x :: y :: xs -> helper (y :: xs) (x + y)
    | _ -> None