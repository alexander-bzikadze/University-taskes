#r "./packages/Fuchu/lib/Fuchu.dll" 
#load "contestModule.fs"
module ContestTest =
    open Fuchu
    open System

    let testEq (mes : string) eq1 eq2 =
        try
            Assert.Equal(mes, eq1, eq2)
            printf "%s passed!\n" mes
        with
        | :? Fuchu.AssertException ->
            printf "%s not passed!\n" mes


    //let ``evenList1 with empty`` =
    //    testEq "evenList1 with empty" (Func.evenList1 []) 0

    let ``infiniteLine test1`` =
        testEq "infiniteLine test1" [1] <| Seq.toList (Seq.take 1 Contest.infiniteLine)

    let ``infiniteLine test2`` =
        testEq "infiniteLine test2" [1;2;2] <| Seq.toList (Seq.take 3 Contest.infiniteLine)

    let ``infiniteLine test3`` =
        testEq "infiniteLine test3" [1;2;2;3;3;3] <| Seq.toList (Seq.take 6 Contest.infiniteLine)

    ``infiniteLine test1``    
    ``infiniteLine test2``
    ``infiniteLine test3``
