module Solution6.Tests

open Sem4Tasks
open Solution6
open NUnit.Framework

[<Test>]
let ``Test with 3 connected computers``() = 
  let windows = OS("windows", 1.0)
  let mac = OS("mac", 0.09)
  let linux = OS("linux", 0.3)
  let computers = [Comp(windows, []); Comp(mac, []); Comp(linux, [])]
  computers.[0].Connections <- [computers.[1]; computers.[2]]
  computers.[0].IsInfected <- true
  let network = Net(computers)
  network.Simulate()
  Assert.AreEqual(network.comps.[0].IsInfected, true)
  Assert.AreEqual(network.comps.[1].IsInfected, true)
  Assert.AreEqual(network.comps.[2].IsInfected, true)


[<Test>]
let ``tree correct Construct`` () =
  let mutable tree = new Tree<int>()
  for i in [1..10] do
    Assert.AreEqual(tree.find i, false)
  ()

[<Test>]
let ``tree correct insert`` () =
  let mutable tree = new Tree<int>()
  for i in [1..10] do
    tree.insert i
    Assert.AreEqual(tree.find i, true)
  ()
  for i in [1..10] do
    Assert.AreEqual(tree.find i, true)
  ()

[<Test>]
let ``tree correct delete`` () =
  let mutable tree = new Tree<int>()
  for i in [1..10] do
    tree.insert i
    Assert.AreEqual(tree.find i, true)
  ()
  for i in [1..10] do
    Assert.AreEqual(tree.find i, true)
  ()
  for i in [1..10] do
    tree.delete i
    Assert.AreEqual(tree.find i, false)
  ()
  for i in [1..10] do
    Assert.AreEqual(tree.find i, false)
  ()

[<Test>]
let ``tree correct iterator`` () =
  let mutable tree = new Tree<int>()
  for i in [1..10] do
    tree.insert i
    Assert.AreEqual(tree.find i, true)
  ()
  for i in [1..10] do
    Assert.AreEqual(tree.find i, true)
  ()
  let mutable value = 1
  for elem in tree do
    Assert.AreEqual(elem, value)
    value <- value + 1

[<Test>]
let ``tree correct iterator with random order of containment`` () =
  let mutable tree = new Tree<int>()
  for i in [1..2] do
    tree.insert i
    Assert.AreEqual(tree.find i, true)
  ()
  for i in [9..10] do
    tree.insert i
    Assert.AreEqual(tree.find i, true)
  ()
  for i in [3..8] do
    tree.insert i
    Assert.AreEqual(tree.find i, true)
  ()
  for i in [1..10] do
    Assert.AreEqual(tree.find i, true)
  ()
  let mutable value = 1
  for elem in tree do
    Assert.AreEqual(elem, value)
    value <- value + 1

