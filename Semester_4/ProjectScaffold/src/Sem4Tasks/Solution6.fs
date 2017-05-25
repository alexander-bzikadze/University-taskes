namespace Sem4Tasks

/// Documentation for Solution6
/// Solution6 is a library of solutions. Hmmm, strong with the obvious, this one is.
module Solution6 = 
  type OS(name : string, probability : double) =
    member val Name = name with get
    member val Probability = probability with get

  type Comp(os : OS, connected : Comp list) =
    member val Os = os with get
    member val Connections = connected with get, set
    member val InfectionTime = 0 with get, set

  type Net(comps : Comp list) =
    let random = System.Random()
    let mutable time = 1

    let areInfected() =
      not <| List.exists (fun (comp : Comp) -> comp.InfectionTime <> time) comps

    member this.SpreadInfection() =
      for comp in comps do
        if comp.InfectionTime = time then
          for connectedComp in comp.Connections do
            if connectedComp.InfectionTime <> time && random.NextDouble() <= connectedComp.Os.Probability then
              connectedComp.InfectionTime <- time + 1
          comp.InfectionTime <- time + 1
      time <- time + 1

    member val comps = comps with get

    /// Tries to infect all the computers in the net
    member this.Simulate() =
      while (not <| areInfected()) do
        this.SpreadInfection()
        let boolToInt b = if b then 1 else 0
        // Does we need more exact output on the net's state?
        printf "%d computers are infected\n" <| List.fold (fun x (y : Comp) -> x + (y.InfectionTime = time |> boolToInt)) 0 comps




  type Node<'a> =
    | Empty
    | Branch of Node<'a> * 'a * Node<'a>

  type TreeIterator<'a when 'a : comparison>(root : Node<'a>) = //'
    let getList =
      let rec helper root =
        match root with
        | Branch (l, x, r) -> List.append <| List.append (helper l) (List.singleton x) <| (helper r)
        | Empty -> []
      helper
    let mutable index = -1
    let list = getList root
    let length = List.length list

    interface System.Collections.Generic.IEnumerator<'a> with //'
      member this.MoveNext() = 
          index <- index + 1
          index = length
      member this.Reset() = 
          index <- -1
      member this.Current = list.[index]
      member this.Dispose() = ()
      member this.get_Current() = (this :> System.Collections.Generic.IEnumerator<'a>).Current :> obj //'

  /// Simple binary tree with iterator
  type Tree<'a when 'a : comparison>() = 
    let mutable root = Empty
    member this.Insert elem =
      let rec ins root elem =
        match root with
        | Empty -> Branch (Empty, elem, Empty)
        | Branch (_, elem, _) -> root
        | Branch (l, x, r) when x > elem -> Branch (ins l elem, x, r)
        | Branch (l, x, r) when x < elem -> Branch (l, x, ins r elem)
      root <- ins root elem

    member this.Find =
      let rec fin root elem =
        match root with
        | Empty -> false
        | Branch (_, elem, _) -> true
        | Branch (l, x, _) when x > elem -> fin l elem
        | Branch (_, x, r) when x < elem -> fin r elem
      fin root

    member this.Delete elem =
      let rec findLeft root =
        match root with
        | Empty -> raise <| System.Exception("Unexpected path in Solution6.Tree<a>.delete.findLeft!")
        | Branch (Empty, x, l) -> (x, l)
        | Branch (r, x, l) ->
          let (a, b) = findLeft r
          (a, Branch(b, x, l))
      let rec del root elem =
        match root with
        | Empty -> Empty
        | Branch (l, elem, Empty) -> l
        | Branch (l, elem, (Branch (Empty, re, r))) -> 
          Branch (l, re, r)
        | Branch (l, elem, r) -> 
          let (a, b) = findLeft r
          Branch (l, a, b)
        | Branch (l, x, r) when x > elem -> Branch (del l elem, x, r)
        | Branch (l, x, r) when x < elem -> Branch (l, x, del r elem)
      root <- del root elem

    interface System.Collections.Generic.IEnumerable<'a> with //'
      member this.GetEnumerator() = new TreeIterator<'a>(root):>System.Collections.Generic.IEnumerator<'a>
      member this.GetEnumerator() = (new TreeIterator<'a>(root):>System.Collections.Generic.IEnumerator<'a>) :> System.Collections.IEnumerator




