using MinimalApiPlayground.Modules.Weather.Models;

namespace MinimalApiPlayground.Modules.Weather;

public class GetWeatherForecasts
{
    public static async Task<IEnumerable<WeatherForecast>> Handler(IWeatherForecastService weatherForecastService) => await weatherForecastService.GetWeatherForecastsAsync();
}
