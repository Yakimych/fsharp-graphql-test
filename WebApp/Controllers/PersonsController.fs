namespace WebApp.Controllers

open Microsoft.AspNetCore.Mvc
open WebApp.GraphCool
open FSharp.Data.GraphQL

[<ApiController>]
[<Route("[controller]")>]
type PersonsController() =
    inherit ControllerBase()

    let runtimeContext =
        { ServerUrl = "https://api.graph.cool/simple/v1/cjdgba1jw4ggk0185ig4bhpsn"
          HttpHeaders = [] }

    [<HttpGet>]
    member __.GetPersons(): string [] =
        let result = allPersonsOperation.Run(runtimeContext)

        match (result.Data, result.Errors) with
        | Some data, [||] -> data.AllPersons |> Array.map (fun p -> p.Name)
        | _ -> [||]
