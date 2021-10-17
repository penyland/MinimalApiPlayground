using MinimalApiPlayground.Modules.Weather.Models;

namespace MinimalApiPlayground.Modules.Weather;

public class WeatherModule : IModule
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/weather", GetWeatherForecastsQuery.Handle);

        endpoints.MapGet("/weather/{id}", async (int id, IWeatherForecastService weatherForecastService) =>
        {
            return await weatherForecastService.GetWeatherForecastAsync(id);
        })
        .Produces<IEnumerable<WeatherForecast>>(StatusCodes.Status200OK);

        return endpoints;
    }

    public IServiceCollection RegisterModule(IServiceCollection services)
    {
        services.AddSingleton<IWeatherForecastService, WeatherForecastService>();
        return services;
    }
}
