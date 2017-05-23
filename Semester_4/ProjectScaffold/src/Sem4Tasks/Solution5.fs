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
  let func' x = List.map (fun y -> y * x)
  let func'' x = List.map <| (*) x
  let freeFunc = List.map << (*)

  type TeleLine =
    Line of string * string

  /// Func to initialize work of a phoneDataBase
  /// Shuts down on 1
  let phoneDataBase =
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
    let readUp originalListOfTele =
      try
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
      with
      | _ -> 
        printf "Error when opening ./phoneDataBase, continuing work without loading.\n"
        originalListOfTele

    let rec nextStep listOfTele =
      let rec helper state listOfTele =
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
          let listOfTele = readUp listOfTele
          nextStep listOfTele
        | 8 -> 
          printf "Shame on you, the one who askes for help\n"
          printf "Enter 1 to exit\n"
          printf "Enter 2 to enter new record\n"
          printf "Enter 3 to search for a name\n"
          printf "Enter 4 to search for a phone number\n"
          printf "Enter 5 to print data base\n"
          printf "Enter 6 to save data base to ./phoneDataBase\n"
          printf "Enter 7 to read data base from ./phoneDataBase\n"
          printf "Enter 8 to for help (no more help than that you won't get)\n"
          printf "Enter anything else to crush me with an error\n"
          nextStep listOfTele
        | _ -> 1
      printf "Enter new state number (8 for help)\n"
      let state = System.Console.ReadLine()
      helper (state |> int) (listOfTele)

    nextStep []

  type Expr = 
  | Var of string
  | Apply of Expr * Expr
  | Lam of string * Expr


  let subst substed substing inTerm =
    let rec helper substed substing expr l =
      match expr with
      | Var (t) -> if t = substed && List.exists (fun x -> x = substed) l <> true then substing else expr
      | Lam (par, expr) -> Lam (par, helper substed substing expr (par::l))
      | Apply (expr1, expr2) -> Apply (helper substed substing expr1 l, helper substed substing expr2 l)
    helper substed substing inTerm []

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
  let rec reduce expr =
    match reduceOnce expr with
    | Some e -> reduce e
    | _ -> expr



