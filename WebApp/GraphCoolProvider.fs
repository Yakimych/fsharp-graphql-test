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
