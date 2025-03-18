using Microsoft.AspNetCore.Mvc;
using TailorPadi.Core.Service.Interface;

namespace TailorPadi.WebAPI.Controllers;
[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly ITestService _testService;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, ITestService testService)
    {
        _logger = logger;
        _testService = testService;
    }

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

    [HttpGet("names")]
    public IActionResult GetNames()
    {
        var names = _testService.GetNames();
        return Ok(names);
    }
}
