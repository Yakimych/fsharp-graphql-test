namespace WebApp.Controllers

open Microsoft.AspNetCore.Mvc
open WebApp.GraphCool
open FSharp.Data.GraphQL
open FSharp.Core

[<ApiController>]
[<Route("[controller]")>]
type PersonsController() =
    inherit ControllerBase()

    let runtimeContext =
        { ServerUrl = "https://api.graph.cool/simple/v1/cjdgba1jw4ggk0185ig4bhpsn"
          HttpHeaders = [] }

    let extractName (personObject: MyProvider.Operations.Q.Types.AllPersonsFields.Person) =
        personObject.Name

    [<HttpGet>]
    member __.GetPersons() =
        let result = allPersonsOperation.Run(runtimeContext)
        getPersonNames result |> List.map extractName

