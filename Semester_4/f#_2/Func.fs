module Func

open System;
open System.Numerics;

let rec sum_n_count n = 
    match n with
        | _ when 0 <= n && n < 10 -> n
        | _ when n < 0 -> - sum_n_count (- n)
        | _ -> (n % 10) * sum_n_count (n / 10)

let first_pos x xs =
    if List.length <| List.filter (fun a -> a = x) xs > 0 then
        let rec helper x xs = 
            match xs with
                | [] -> 0
                | a::tail -> if (a = x) then 0 else 1 + helper x tail
        helper x xs
    else
        -1

let pal xs =
    List.rev xs = xs


let rec mergesort xs =
    let rec merge : int list * int list -> int list = 
        fun (ax, bx) ->
            match (ax, bx) with
                | [], [] -> [] 
                | _, [] -> ax
                | [], _ -> bx
                | a::atail, b::btail when a < b -> a :: merge (atail, bx)
                | a::atail, b::btail -> b :: merge (ax, btail)
    match xs with
    | [] -> []
    | [a] -> [a]
    | _ -> 
        let a, b = List.splitAt (List.length xs / 2) xs
        merge (mergesort a, mergesort b)

let mergesort_2 = List.sortBy (fun elem -> abs elem)