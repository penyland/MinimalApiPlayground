using Microsoft.AspNetCore.Mvc;

namespace MinimalApiPlayground.Modules.Weather;

public class WeatherModule : IModule
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/weather", GetWeatherForecasts.Handler);

        endpoints.MapGet("/weather/{id}", async ([FromRoute] int id, [FromServices] IWeatherForecastService weatherForecastService) => 
        { 
            return await weatherForecastService.GetWeatherForecastAsync(id);
        });

        return endpoints;
    }

    public IServiceCollection RegisterModule(IServiceCollection services)
    {
        services.AddSingleton<IWeatherForecastService, WeatherForecastService>();
        return services;
    }
}
