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
  computers.[0].InfectionTime <- 1
  let network = Net(computers)
  network.Simulate()
  Assert.IsTrue(network.comps.[0].InfectionTime <> 0)
  Assert.IsTrue(network.comps.[1].InfectionTime <> 0)
  Assert.IsTrue(network.comps.[2].InfectionTime <> 0)


[<Test>]
let ``tree correct Construct`` () =
  let mutable tree = new Tree<int>()
  for i in [1..10] do
    Assert.IsFalse(tree.Find i)
  ()

[<Test>]
let ``tree correct Insert`` () =
  let mutable tree = new Tree<int>()
  for i in [1..10] do
    tree.Insert i
    Assert.IsTrue(tree.Find i)
  ()
  for i in [1..10] do
    Assert.IsTrue(tree.Find i)
  ()

[<Test>]
let ``tree correct Delete`` () =
  let mutable tree = new Tree<int>()
  for i in [1..10] do
    tree.Insert i
    Assert.IsTrue(tree.Find i)
  ()
  for i in [1..10] do
    Assert.IsTrue(tree.Find i)
  ()
  for i in [1..10] do
    tree.Delete i
    Assert.IsFalse(tree.Find i)
  ()
  for i in [1..10] do
    Assert.IsFalse(tree.Find i)
  ()

[<Test>]
let ``tree correct iterator`` () =
  let mutable tree = new Tree<int>()
  for i in [1..10] do
    tree.Insert i
    Assert.IsTrue(tree.Find i)
  ()
  for i in [1..10] do
    Assert.IsTrue(tree.Find i)
  ()
  let mutable value = 1
  for elem in tree do
    Assert.AreEqual(elem, value)
    value <- value + 1

[<Test>]
let ``tree correct iterator with random order of containment`` () =
  let mutable tree = new Tree<int>()
  for i in [1..2] do
    tree.Insert i
    Assert.IsTrue(tree.Find i)
  ()
  for i in [9..10] do
    tree.Insert i
    Assert.IsTrue(tree.Find i)
  ()
  for i in [3..8] do
    tree.Insert i
    Assert.IsTrue(tree.Find i)
  ()
  for i in [1..10] do
    Assert.IsTrue(tree.Find i)
  ()
  let mutable value = 1
  for elem in tree do
    Assert.AreEqual(elem, value)
    value <- value + 1

