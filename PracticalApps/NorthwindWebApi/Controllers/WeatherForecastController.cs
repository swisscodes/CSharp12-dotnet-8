using Microsoft.AspNetCore.Mvc;

namespace NorthwindWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        //[HttpGet(Name = "GetWeatherForecastFiveDays")]
        //public IEnumerable<WeatherForecast> GetWeatherForecastFiveDays()
        //{
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
        //        TemperatureC = Random.Shared.Next(-20, 55),
        //        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //    }).ToArray();
        //}

        // GET /weatherforecast
        [HttpGet(Name = "GetWeatherForecastFiveDays")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Get(days: 5); // Five-day forecast.
        }
        // GET /weatherforecast/7
        [HttpGet(template: "{days:int}", Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get(int days)
        {
            return Enumerable.Range(1, days).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            }).ToArray();
        }

    }
}
