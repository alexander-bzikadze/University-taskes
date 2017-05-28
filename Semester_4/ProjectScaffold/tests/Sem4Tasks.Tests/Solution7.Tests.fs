module Solution7.Tests

open Sem4Tasks
open Solution7
open NUnit.Framework

[<Test>]
let ``rounding classic test`` () =
  Assert.AreEqual(rounding 3 {
      let! a = 2.0 / 12.0
      let! b = 3.5
      return a / b
  }, 0.048)

[<Test>]
let ``rounding negative numbers test`` () =
  Assert.AreEqual(rounding 3 {
      let! a = -2.0
      let! b = 50.0
      return a / b
  }, -0.04)

[<Test>]
let ``calculate classic success test`` () =
  let result = calculate () {
        let! x = "1"
        let! y = "2"
        let z = x + y
        return z
    }
  Assert.AreEqual(result, Some 3)

[<Test>]
let ``calculate classic fail test`` () =
  let result = calculate () {
        let! x = "1"
        let! y = "Ъ"
        let z = x + y
        return z
    }
  Assert.AreEqual(result, None)