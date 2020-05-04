namespace ApiLib.Weather

open System

module WeatherLogic =

    type WeatherForecast =
        { Date: DateTime
          TemperatureC: int
          Summary: string }

    let summaries =
        [| "Freezing"
           "Bracing"
           "Chilly"
           "Cool"
           "Mild"
           "Warm"
           "Balmy"
           "Hot"
           "Sweltering"
           "Scorching" |]

    let getForecast () =
        let rng = System.Random()
        [| for index in 0 .. 4 ->
            { Date = DateTime.Now.AddDays(float index)
              TemperatureC = rng.Next(-20, 55)
              Summary = summaries.[rng.Next(summaries.Length)] } |]
