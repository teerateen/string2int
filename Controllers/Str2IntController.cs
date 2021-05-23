using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace test_str2int.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Str2IntController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<Str2IntController> _logger;

        public Str2IntController(ILogger<Str2IntController> logger)
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
        }

        [HttpGet("[action]/{text?}")]
        public string String2Int(string text)
        {
            string textNunber = "";
            Regex regex = new Regex("^[0-9]+$");
            for (int i = 0; i < text.Length; i++)
            {
                if (regex.IsMatch(text.ToCharArray()[i] + ""))
                {
                    textNunber += text.ToCharArray()[i] + "";
                }
            }

            return textNunber;
        }
    }
}
