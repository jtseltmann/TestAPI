using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace TestAPI.Controllers
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

        public class PersonRequest()
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Action { get; set; }
        }

        [HttpGet]
        [Route("GetWeatherForecast")]
        public IEnumerable<WeatherForecast> GetWeatherForecast()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost]
        [Route("ValidatePerson")]
        public string ValidatePerson([FromBody]PersonRequest request)
        {
            return $"The personal information you passed is: {request.FirstName} {request.LastName}";
        }


        [HttpPost]
        [Route("UpdatePerson")]
        public IActionResult UpdatePerson([FromBody] PersonRequest request)
        {
            if (request.FirstName == "Chris")
                request.FirstName = "BossMan";
            request.Action = "DONE";
            return Ok(request);
        }
    }
}
