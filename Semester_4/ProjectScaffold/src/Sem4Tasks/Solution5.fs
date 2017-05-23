namespace Sem4Tasks

/// Documentation for Solution5
/// Solution5 is a library of solutions. Hmmm, strong with the obvious, this one is.
module Solution5 = 
  open System.IO

  /// Check brackets for correctness
  let bestStack str =
    let rec helper str stack =
      match (str, stack) with
      | ([], []) -> true
      | ([], _) -> false
      | (('(' :: st), stack) -> helper st ('(' :: stack)
      | (('[' :: st), stack) -> helper st ('[' :: stack)
      | (('{' :: st), stack) -> helper st ('{' :: stack)
      | ((')' :: st), ('(' :: stac)) -> helper st stac
      | ((']' :: st), ('[' :: stac)) -> helper st stac
      | (('}' :: st), ('{' :: stac)) -> helper st stac
      | ((')' :: _), _) -> false
      | ((']' :: _), _) -> false
      | (('}' :: _), _) -> false
      | ((_ :: st), stack) -> helper st stack

    helper [for c in str -> c] []

  /// Functions for perverts
  let func x l = List.map (fun y -> y * x) l
  let freeFunc = List.map << (*)

  type TeleLine =
    Line of string * string

  /// Func to initialize work of a phoneDataBase
  /// Shuts down on 1
  let phoneDataBase state =
    let rec nameSearch name = List.exists (fun (Line (x, _)) -> x = name)
    let rec numberSearch number = List.exists (fun (Line (_, x)) -> x = number)
    let rec print listOfTele =
      match listOfTele with
      | ((Line (name, number)) :: l) ->
        printf "%s %s\n" name number
        print l
      | _ -> 0
    let writeDown listOfTele =
      use file = System.IO.File.CreateText("./phoneDataBase")
      for line in listOfTele do
        let (Line (name, number)) = line
        fprintf file "%s %s\n" name number
    let readUp () =
      use file = new StreamReader "./phoneDataBase"
      let mutable valid = true
      let mutable listOfTele = []
      while (valid) do 
        let line = file.ReadLine()
        if (line = null) then
            valid <- false
        else
          let name = line.Split(' ').[0]
          let number = line.Split(' ').[1]
          listOfTele <- Line (name, number) :: listOfTele
      listOfTele

    let rec helper state listOfTele =
      let rec nextStep listOfTele =
        printf "Enter new state number\n"
        let state = System.Console.ReadLine()
        helper (state |> int) (listOfTele)
      match state with
      | 1 -> 
        printf "Exit"
        0
      | 2 ->
        printf "Enter new name\n"
        let name = System.Console.ReadLine()
        printf "Enter new number\n"
        let number = System.Console.ReadLine()
        nextStep (Line (name, number) :: listOfTele)
      | 3 ->
        printf "Enter a name to search for\n"
        let name = System.Console.ReadLine()
        printf "%b\n" <| nameSearch name listOfTele
        nextStep listOfTele
      | 4 ->
        printf "Enter a number to search for\n"
        let number = System.Console.ReadLine()
        printf "%b\n" <| numberSearch number listOfTele
        nextStep listOfTele
      | 5 ->
        print listOfTele |> ignore
        nextStep listOfTele
      | 6 ->
        writeDown listOfTele
        nextStep listOfTele
      | 7 ->
        let listOfTele = readUp ()
        nextStep listOfTele
      | _ -> 1

    helper state []

  type Expr = 
  | Var of string
  | Apply of Expr * Expr
  | Lam of string * Expr


  let subst v n m =
    let rec helper v n expr l =
      match expr with
      | Var (t) -> if t = v && List.exists (fun x -> x = v) l <> true then n else expr
      | Lam (par, expr) -> Lam (par, helper v n expr (par::l))
      | Apply (expr1, expr2) -> Apply (helper v n expr1 l, helper v n expr2 l)
    helper v n m []

  let rec reduceOnce expr =
    match expr with
    | Var _ -> None
    | Apply (Lam (par, expr1), expr2) -> Some <| subst par expr2 expr1
    | Apply (expr1, expr2) ->
      match reduceOnce expr1 with
      | Some p -> Some <| Apply (p, expr2)
      | _ -> 
        match reduceOnce expr2 with
        | Some q -> Some <| Apply (expr1, q)
        | _ -> None
    | Lam (par, expr) ->
      match reduceOnce expr with
      | Some p -> Some <| Lam (par, p)
      | _ -> None

  /// Lambda calculator
  let reduce expr =
    let mutable ret_expr = expr
    let mutable res = reduceOnce expr
    while (res <> None) do
      match res with
      | Some e ->
        ret_expr <- e
        res <- reduceOnce e
      | _ -> ()
    
    ret_expr



