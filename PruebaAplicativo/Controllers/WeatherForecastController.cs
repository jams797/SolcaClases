using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PruebaAplicativo.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly InterfacesModel service;
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, InterfacesModel service)
    {
        _logger = logger;
        this.service = service;
    }
}
