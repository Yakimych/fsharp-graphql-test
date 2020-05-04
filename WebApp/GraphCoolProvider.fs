module WebApp.GraphCool

open FSharp.Data.GraphQL

type MyProvider = GraphQLProvider<"schema.json">

let allPersonsOperation =
    MyProvider.Operation<"""query q {
      allPersons {
        name
        id
      }
    }""">()

let getPersonNames2 (runtimeContext) =
    let result = allPersonsOperation.Run(runtimeContext)
    match (result.Data, result.Errors) with
    | Some data, [||] -> data.AllPersons |> List.ofArray
    | _ -> []

let getPersonNames (result: MyProvider.Operations.Q.OperationResult) : MyProvider.Operations.Q.Types.AllPersonsFields.Person list =
    match (result.Data, result.Errors) with
    | Some data, [||] -> data.AllPersons |> Array.toList
    | _ -> []
