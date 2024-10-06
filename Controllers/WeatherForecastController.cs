using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace MiniKubeApi8.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController(ILogger<WeatherForecastController> logger, IConfiguration configuration) : ControllerBase
    {
        
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("snow",Name ="GetSnow")]
        public string GetSnow()
        {
            logger.LogDebug("something to debug...");
            return "snow is falling at: " + DateTime.Now.ToString();
        }

        [HttpGet("secrets", Name = "Secrets")]
        public string ShowSecrets(IHostEnvironment env) 
        {
            const string key = "DefaultConnection";
            logger.LogInformation($"danger zone - spilling secrets. Env: {env.EnvironmentName}");
            
            //IConfigurationSection dbSettings = configuration.GetSection("ConnectionStrings");
            var dbConn = configuration.GetConnectionString(key);
            
            return $"Database: {key} = '{dbConn}' Env:{env.EnvironmentName}";
        }
    }
}
