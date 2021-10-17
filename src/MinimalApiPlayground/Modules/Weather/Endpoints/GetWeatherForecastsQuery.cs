using Microsoft.AspNetCore.Mvc;
using MinimalApiPlayground.Modules.Weather.Models;

namespace MinimalApiPlayground.Modules.Weather;

public static class GetWeatherForecastsQuery
{
    [ProducesResponseType(typeof(IEnumerable<WeatherForecast>), StatusCodes.Status200OK)]
    public static async Task<IEnumerable<WeatherForecast>> Handle(IWeatherForecastService weatherForecastService) => await weatherForecastService.GetWeatherForecastsAsync();
}
