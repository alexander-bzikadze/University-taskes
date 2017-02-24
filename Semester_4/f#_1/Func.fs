module Func

open System.Numerics;

let rec factorial (n : int) =
    if n = 0 then
        bigint 1
    else 
        (*) (bigint n) (factorial (n - 1))

let fibonacci n = 
    let rec helper a b n =
            match n with
                | 0 -> b
                | _ -> helper (a + b) a (n - 1)

    helper 1 0 n

let reverse xs =
    let rec helper ax bx = 
        match ax with
            | [] -> bx
            | x::tail -> helper tail (x::bx)
    
    helper xs []

let listOfTwoes start length =
    [start .. (start + length)] |> List.map (pown 2)
