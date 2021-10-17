using MinimalApiPlayground.Modules.Weather.Models;

namespace MinimalApiPlayground.Modules.Weather;

public interface IWeatherForecastService
{
    Task<IEnumerable<WeatherForecast>> GetWeatherForecastsAsync();

    Task<WeatherForecast?> GetWeatherForecastAsync(int id);
}
