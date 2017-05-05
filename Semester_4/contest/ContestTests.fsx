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
            Console.WriteLine ("Got {0} instead of {1}", eq1, eq2)

    let ``infiniteLine test1`` =
        testEq "infiniteLine test1" [1] <| Seq.toList (Seq.take 1 Contest.infiniteLine)

    let ``infiniteLine test2`` =
        testEq "infiniteLine test2" [1;2;2] <| Seq.toList (Seq.take 3 Contest.infiniteLine)

    let ``infiniteLine test3`` =
        testEq "infiniteLine test3" [1;2;2;3;3;3] <| Seq.toList (Seq.take 6 Contest.infiniteLine)

    let ``Queue test1: order 1 2 3`` =
        testEq "Queue test1: order 1 2 3" 1 <| (fun _ -> 
                                        let q = new Contest.PriorityQueue<int>()
                                        q.push(1);
                                        q.push(2);
                                        q.push(3);
                                        q.top) ()

    let ``Queue test2: order 3 2 1`` =
        testEq "Queue test2: order 3 2 1" 1 <| (fun _ -> 
                                        let q = new Contest.PriorityQueue<int>()
                                        q.push(3);
                                        q.push(2);
                                        q.push(1);
                                        q.top) ()

    let ``Queue test3: order 2 1 2`` =
        testEq "Queue test3: order 2 1 2" 1 <| (fun _ -> 
                                        let q = new Contest.PriorityQueue<int>()
                                        q.push(2);
                                        q.push(1);
                                        q.push(2);
                                        q.top) ()

    let ``Queue test4: order 2 1 1 pop`` =
        testEq "Queue test4: order 2 1 1 pop" 1 <| (fun _ -> 
                                        let q = new Contest.PriorityQueue<int>()
                                        q.push(2);
                                        q.push(1);
                                        q.push(1);
                                        q.pop;
                                        q.top) ()

    let ``Queue test5: order 2 1 2 pop`` =
        testEq "Queue test5: order 2 1 2 pop" 2 <| (fun _ -> 
                                        let q = new Contest.PriorityQueue<int>()
                                        q.push(2);
                                        q.push(1);
                                        q.push(2);
                                        q.pop;
                                        q.top) ()

    let ``Queue test6: order 2 1 2 pop pop`` =
        testEq "Queue test6: order 2 1 2 pop pop" 2 <| (fun _ -> 
                                        let q = new Contest.PriorityQueue<int>()
                                        q.push(2);
                                        q.push(1);
                                        q.push(2);
                                        q.pop;
                                        q.pop;
                                        q.top) ()

    let ``Queue test6: pop Exception`` =
        testEq "Queue test6: pop Exception (IF 0 then no Exception called)" 1 <| (fun _ -> 
                                        let q = new Contest.PriorityQueue<int>()
                                        try
                                            q.pop;
                                            0
                                        with
                                        | :? System.Exception ->
                                            1) ()

    let ``Queue test6: 1 pop pop Exception`` =
        testEq "Queue test6: 1 pop pop (IF 0 then no Exception called)" 1 <| (fun _ -> 
                                        let q = new Contest.PriorityQueue<int>()
                                        try
                                            q.push(1);
                                            q.pop;
                                            q.pop;
                                            0
                                        with
                                        | :? System.Exception ->
                                            1) ()

    let ``Queue test6: top Exception`` =
        testEq "Queue test6: top Exceptio (IF 0 then no Exception called)" 1 <| (fun _ -> 
                                        let q = new Contest.PriorityQueue<int>()
                                        try
                                            q.top;
                                            0
                                        with
                                        | :? System.Exception ->
                                            1) ()

    let ``Queue test6: 1 pop top Exception`` =
        testEq "Queue test6: 1 pop top Exception (IF 0 then no Exception called)" 1 <| (fun _ -> 
                                        let q = new Contest.PriorityQueue<int>()
                                        try
                                            q.push(1);
                                            q.pop;
                                            q.top;
                                            0
                                        with
                                        | :? System.Exception ->
                                            1) ()
