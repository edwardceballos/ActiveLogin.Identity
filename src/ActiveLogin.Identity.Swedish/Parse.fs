module internal ActiveLogin.Identity.Swedish.FSharp.Parse

open System
open System.Text.RegularExpressions

type Delimiter =
    | Plus
    | Hyphen

type NumberParts =
    { FullYear : int option
      ShortYear : int option
      Month : int
      Day : int
      Delimiter : Delimiter
      BirthNumber : int
      Checksum : int }

let private buildNumberParts (gs : GroupCollection) =
    let asString (k : string) (gs : GroupCollection) =
        let value = gs.[k].ToString()
        if String.IsNullOrWhiteSpace value then None
        else Some value

    let asInt (k : string) (gs : GroupCollection) =
        gs
        |> asString k
        |> Option.map Int32.Parse

    let asDelimiter (gs : GroupCollection) =

        gs
        |> asString "delimiter"
        |> function
        | Some d when d = "+" -> Plus
        | Some d when d = "-" || d = " " -> Hyphen
        | None -> Hyphen
        | _ -> invalidArg "gs" "Invalid delimiter"

    { FullYear = asInt "fullYear" gs
      ShortYear = asInt "shortYear" gs
      Month =
          match asInt "month" gs with
          | Some m -> m
          | None -> invalidArg "gs" "Invalid month"
      Day =
          match asInt "day" gs with
          | Some m -> m
          | None -> invalidArg "g" "Invalid day"
      Delimiter = asDelimiter gs
      BirthNumber =
          match asInt "birthNumber" gs with
          | Some m -> m
          | None -> invalidArg "gs" "Invalid birth number"
      Checksum =
          match asInt "checksum" gs with
          | Some m -> m
          | None -> invalidArg "gs" "Invalid checksum" }

let (|SwedishIdentityNumber|_|) (input : NonEmptyString) =
    let input = input |> NonEmptyString.value;
    let matchRegex pattern input = Regex.Match(input, pattern)
    let pattern = @"^" + 
                  @"((?<fullYear>[0-9]{4})|(?<shortYear>[0-9]{2}))" + 
                  @"(?<month>[0-9]{2})" + 
                  @"(?<day>[0-9]{2})" + 
                  @"(?<delimiter>[-+ ]?)" + 
                  @"(?<birthNumber>[0-9]{3})" + 
                  @"(?<checksum>[0-9]{1})" + 
                  @"$"
    let m = input.Trim() |> matchRegex pattern
    match m.Success with
    | true ->
        m.Groups
        |> buildNumberParts
        |> Some
    | false -> None
