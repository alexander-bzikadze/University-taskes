#r "./packages/Fuchu/lib/Fuchu.dll" 
#load "Func.fs"
module FuncTest =
    open Fuchu
    open System

    let testEq (mes : string) eq1 eq2 =
        try
            Assert.Equal(mes, eq1, eq2)
            printf "%s passed!\n" mes
        with
        | :? Fuchu.AssertException ->
            printf "%s not passed!\n" mes


    let ``evenList1 with empty`` =
        testEq "evenList1 with empty" (Func.evenList1 []) 0

    let ``evenList1 with one element`` =
        testEq "evenList1 with one element" (Func.evenList1 [1]) 0

    let ``evenList1 with random`` =
        testEq "evenList1 with random" (Func.evenList1 [1;2;3;4;5;6]) 3

    let ``evenList2 with empty`` =
        testEq "evenList2 with empty" (Func.evenList2 []) 0

    let ``evenList2 with one element`` =
        testEq "evenList2 with one element" (Func.evenList2 [1]) 0

    let ``evenList2 with random`` =
        testEq "evenList2 with random" (Func.evenList2 [1;2;3;4;5;6]) 3

    let ``evenList3 with empty`` =
        testEq "evenList3 with empty" (Func.evenList3 []) 0

    let ``evenList3 with one element`` =
        testEq "evenList3 with one element" (Func.evenList3 [1]) 0

    let ``evenList3 with random`` =
        testEq "evenList3 with random" (Func.evenList3 [1;2;3;4;5;6]) 3s

    let ``treeMap with empty`` =
        testEq "treeMap with empty" (Func.treeMap (fun x -> x * 2) <| Func.Empty) Func.Empty

    let ``treeMap with one element`` =
        testEq "treeMap with one element" (Func.treeMap (fun x -> x * 2) <| Func.Node (1, Func.Empty, Func.Empty)) <| Func.Node (2, Func.Empty, Func.Empty)

    let randTree =
        Func.Node (1, Func.Node (2, Func.Empty, Func.Empty), Func.Node (3, Func.Empty, Func.Empty))
    let randTreeTo =
        Func.Node (3, Func.Node (4, Func.Empty, Func.Empty), Func.Node (5, Func.Empty, Func.Empty))

    let ``treeMap with random`` =
        testEq "treeMap with random" (Func.treeMap (fun x -> x + 2) randTree) randTreeTo

    let ``countB test`` =
        testEq "countB test" (Func.countB (Func.Multiply (Func.Var 1, Func.Var 2))) 2

    let ``seqPrime test`` =
        testEq "seqPrime test" (Seq.fold (+) 0 <| (Seq.take 3 <| Func.seqPrime)) 10





