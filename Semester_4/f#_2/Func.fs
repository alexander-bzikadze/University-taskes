module Func

open System;
open System.Numerics;

let rec prod n = 
    match n with
        | _ when 0 <= n && n < 10 -> n
        | _ when n < 0 -> -prod (- n)
        | _ -> (n % 10) * prod (n / 10)

let firstPos x xs =
    let rec helper x xs (index : int) = 
        match xs with
            | [] -> None
            | a::tail when a = x -> Some(index)
            | a::tail -> helper x tail (index + 1)
    helper x xs 0

let pal (str : String) =
    let xs = [for c in str -> c]
    List.rev xs = xs


let rec mergeSort xs =
    let rec merge ax bx acc = 
        match (ax, bx) with
            | [], [] -> List.rev acc
            | _, [] -> (List.rev acc) @ ax
            | [], _ -> (List.rev acc) @ bx
            | a::atail, b::btail when a < b -> merge atail bx (a :: acc)
            | a::atail, b::btail -> merge ax btail (b :: acc)
    match xs with
    | [] -> []
    | [a] -> [a]
    | _ -> 
        let a, b = List.splitAt (List.length xs / 2) xs
        merge (mergeSort a) (mergeSort b) []

let mergeSort_2 = List.sortBy (fun elem -> abs elem)