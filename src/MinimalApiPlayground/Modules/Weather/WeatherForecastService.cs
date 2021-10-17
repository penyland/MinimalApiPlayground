using MinimalApiPlayground.Modules.Weather.Models;

namespace MinimalApiPlayground.Modules.Weather
{
    public class WeatherForecastService : IWeatherForecastService
    {
    //    private readonly IWeatherForecastDataContainerRepository weatherForecastDataContainerRepository;
    //    private readonly ILogger<WeatherForecastService> logger;

    //    public WeatherForecastService(IWeatherForecastDataContainerRepository weatherForecastDataContainerRepository, ILogger<WeatherForecastService> logger)
    //    {
    //        this.weatherForecastDataContainerRepository = weatherForecastDataContainerRepository ?? throw new ArgumentNullException(nameof(weatherForecastDataContainerRepository));
    //        this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
    //    }

    //    public async Task<IEnumerable<WeatherForecast>> GetWeatherForecastsAsync()
    //    {
    //        logger.LogInformation("Getting forecasts from database.");
    //        return await weatherForecastDataContainerRepository.GetWeatherForecastsAsync();
    //    }

    //    public async Task<WeatherForecast?> GetWeatherForecastAsync(int id)
    //    {
    //        var result = await weatherForecastDataContainerRepository.GetWeatherForecastsAsync(id);
    //        return result.SingleOrDefault();
    //    }

        private static readonly string[] Summaries = new[]
                {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastService> logger;

        public WeatherForecastService(ILogger<WeatherForecastService> logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<WeatherForecast>> GetWeatherForecastsAsync()
        {
            logger.LogInformation("Generating forecasts.");
            var rng = new Random();

            return await Task.Run(() =>
            {
                return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                })
                .ToArray();
            });
        }

        public async Task<WeatherForecast?> GetWeatherForecastAsync(int id)
        {
            return await Task.Run(() =>
            {
                var rng = new Random();
                return new WeatherForecast
                {
                    Id = Guid.NewGuid().ToString(),
                    ForecastId = 1,
                    Date = DateTime.Now,
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                };
            });
        }
    }
}
