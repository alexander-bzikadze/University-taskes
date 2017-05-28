module Solution8.Tests

open Sem4Tasks
open Solution8
open NUnit.Framework

[<Test>]
let ``Vk test`` () = 
  asyncUrlAnalyzis "https://vk.com/alexander.bzikadze"

[<Test>]
let ``github test`` () = 
  asyncUrlAnalyzis "https://github.com/alexander-bzikadze"

[<Test>]
let ``CSC test`` () = 
  asyncUrlAnalyzis "https://compscicenter.ru/users/1642"

[<Test>]
let ``fsharpforfunandprofit test`` () = 
  asyncUrlAnalyzis "https://fsharpforfunandprofit.com/"