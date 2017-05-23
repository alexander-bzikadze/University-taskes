namespace Sem4Tasks

/// Documentation for Solution8
/// Solution8 is a library of solutions. Hmmm, strong with the obvious, this one is.
/// Async analyzis of webpages.
module Solution8 = 
  open System.Net
  open System.IO
  open System.Text.RegularExpressions

  /// Gets links from url adress and prints number of symbols on those pages
  let asyncUrlAnalyzis =
    let urlToText (url : string) = 
      async {
        use! response = WebRequest.Create(url).AsyncGetResponse()
        use reader = new StreamReader(response.GetResponseStream())
        return reader.ReadToEnd()
      }
    let referencesFromText page = 
      let pattern = "<a href=\"http://(.+?)\">"
      let regex = new Regex(pattern, RegexOptions.IgnoreCase)
      let matchesSeq : seq<Match> = (Seq.cast <| regex.Matches page)
      matchesSeq |> Seq.map (fun x -> x.Value.Substring(9, x.Value.Length - 11)) |> Seq.distinct
    let analyze (url : string) = 
      async {
        try 
          let! html = urlToText url
          return (url, Some html.Length)
        with
        | _ -> return (url, None)
      } 
    urlToText
    >> Async.RunSynchronously
    >> referencesFromText 
    >> Seq.map (analyze >> (fun y -> 
        async {
          let! url, x = y
          match x with
          | Some number -> printf "Link %s has %d symbols\n" url number
          | _ -> printf "Failed to download link %s\n" url
        }))
    >> Async.Parallel
    >> Async.RunSynchronously
    >> ignore

