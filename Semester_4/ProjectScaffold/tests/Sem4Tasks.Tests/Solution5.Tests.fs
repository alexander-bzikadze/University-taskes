module Solution5.Tests

open Sem4Tasks
open NUnit.Framework

[<Test>]
let ``bestStack ((( test`` () =
  Assert.AreEqual(Solution5.bestStack "(((",false)

[<Test>]
let ``bestStack {{{ test`` () =
  Assert.AreEqual(Solution5.bestStack "{{{",false)

[<Test>]
let ``bestStack [[[ test`` () =
  Assert.AreEqual(Solution5.bestStack "[[[",false)

[<Test>]
let ``bestStack ))) test`` () =
  Assert.AreEqual(Solution5.bestStack ")))",false)

[<Test>]
let ``bestStack }}} test`` () =
  Assert.AreEqual(Solution5.bestStack "}}}",false)

[<Test>]
let ``bestStack ]]] test`` () =
  Assert.AreEqual(Solution5.bestStack "]]]",false)

[<Test>]
let ``bestStack ((())) test`` () =
  Assert.AreEqual(Solution5.bestStack "((()))",true)

[<Test>]
let ``bestStack {{{}}} test`` () =
  Assert.AreEqual(Solution5.bestStack "{{{}}}",true)

[<Test>]
let ``bestStack [[[]]] test`` () =
  Assert.AreEqual(Solution5.bestStack "[[[]]]",true)

[<Test>]
let ``bestStack ({[]}) test`` () =
  Assert.AreEqual(Solution5.bestStack "({[]})",true)

[<Test>]
let ``bestStack ({[aaa]}) test`` () =
  Assert.AreEqual(Solution5.bestStack "({[aaa]})",true)

[<Test>]
let ``freeFunc 3 [1;2;3] test`` () =
  Assert.AreEqual(Solution5.freeFunc 3 [1;2;3], [3; 6; 9])

[<Test>]
let ``subst y replace x in (\x -> x y), get \x -> x x test`` () =
  Assert.AreEqual(Solution5.subst "y"  (Solution5.Var "x")  (Solution5.Lam ("x", (Solution5.Apply (Solution5.Var "x", Solution5.Var "y")))), 
                (Solution5.Lam ("x", (Solution5.Apply (Solution5.Var "x", Solution5.Var "x")))))

[<Test>]
let ``reduceOnce (\x -> x) x into x test`` () =
  Assert.AreEqual(Solution5.reduceOnce <| Solution5.Apply (Solution5.Lam ("x", Solution5.Var "x"), Solution5.Var "x"), Some <| Solution5.Var "x")

[<Test>]
let ``reduceOnce (\x -> x) into None test`` () =
  Assert.AreEqual(Solution5.reduceOnce <| Solution5.Lam ("x", Solution5.Var "x"), None)

[<Test>]
let ``reduce (\x -> x) x into x test`` () =
  Assert.AreEqual(Solution5.reduce <| Solution5.Apply (Solution5.Lam ("x", Solution5.Var "x"), Solution5.Var "x"), Solution5.Var "x")

/// Run to test Hmmmm
//[<Test>]
//let ``reduce omega omage into Hmmmm test`` () =
  //let omega = Solution5.Lam ("x", Solution5.Apply (Solution5.Var "x", Solution5.Var "x"))
  //Assert.AreEqual(Solution5.reduce <| Solution5.Apply (omega, omega), omega)




