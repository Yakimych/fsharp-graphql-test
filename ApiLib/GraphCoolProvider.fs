module ApiLib.GraphCool

open FSharp.Data.GraphQL

type MyProvider = GraphQLProvider<"schema.json">

let allPersonsOperation =
    MyProvider.Operation<"""query allPersons {
      allPersons {
        name
        id
      }
    }""">()
