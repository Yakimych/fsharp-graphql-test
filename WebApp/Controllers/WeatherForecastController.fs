namespace WebApp.Controllers

open Microsoft.AspNetCore.Mvc
open ApiLib.Weather

[<ApiController>]
[<Route("[controller]")>]
type WeatherForecastController() =
    inherit ControllerBase()

    [<HttpGet>]
    member __.Get(): WeatherLogic.WeatherForecast [] = WeatherLogic.getForecast ()
