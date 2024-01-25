using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Linq;

namespace WebAppHostSample.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        Random rng = new Random();

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, Serilog.ILogger seriLog)
        {
            _logger = logger;
            _logger.LogDebug("WeatherForecastController created.!!!!!!!!!!!!");

            seriLog.Debug("Hey Seri!!!!!!!!!!!");
        }

        [HttpGet]
        //[Route("")]
        public IEnumerable<WeatherForecast> Get()
        {            
            var result = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();

            _logger.LogDebug("Result weather created.");

            return result;
        }
    }
}
