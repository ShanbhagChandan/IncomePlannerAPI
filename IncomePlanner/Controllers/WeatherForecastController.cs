using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace IncomePlanner.Controllers
{
    [Authorize(Roles = "User,Admin")]
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

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
            //using (var cryptoProvider = new RNGCryptoServiceProvider())
            //{
            //    byte[] bytes = new byte[64];
            //    cryptoProvider.GetBytes(bytes);

            //    string secureRandomString = Convert.ToBase64String(bytes);

            //    // Output example: Secure random string: OfGER+tSZIOSz314OlHk1aM+N8oNXDRHqTn3c5EVknYO5b5s0kqq40lJzoGj99ZXCvoFhkNG8KwQQvBPaR0FtQ==
            //    return secureRandomString;
            //}
        }
    }
}
