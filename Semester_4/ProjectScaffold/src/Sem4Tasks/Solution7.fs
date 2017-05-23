namespace Sem4Tasks

/// Documentation for Solution7
/// Solution7 is a library of solutions. Hmmm, strong with the obvious, this one is.
/// Well, this module consists of workFlows
module Solution7 = 
  
  type rounding (n) =
    let round = fun (x : double) (y : int) -> System.Math.Round (x, y)
    member this.Bind (m, f) =
      f <| round m n
    member this.Return x =
      round x n

  type calculate() =
    let parse str =
      let suc, res = System.Int32.TryParse str
      match suc with
      | true -> Some res
      | _ -> None

    member this.Return (x : string) = 
      parse x

    member this.Return (x : int) = 
      Some x

    member this.Bind (m, f) =
      match parse m  with
      | Some v -> f v
      | _ -> None