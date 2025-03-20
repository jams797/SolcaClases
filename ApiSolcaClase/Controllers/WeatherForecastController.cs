using ApiSolcaClase.Bll.WeatherForecast;
using ApiSolcaClase.Helpers.Functions;
using ApiSolcaClase.Helpers.Models;
using ApiSolcaClase.Models.AppModels.WeatherForecast;
using ApiSolcaClase.Validator.WeatherForecast;
using Microsoft.AspNetCore.Mvc;

namespace ApiSolcaClase.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IConfiguration _configuration;
    private WeatherForecastValidate Valid;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IConfiguration configuration)
    {
        Valid = new WeatherForecastValidate();
        _logger = logger;
        _configuration = configuration;
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


    [HttpPost]
    public ResponseModelGeneral Post([FromBody] WheatherForecastRequestModel resqModel)
    {
        ResponseModelGeneral ValidD = Valid.ValidatePost(resqModel);
        if (ValidD.code != 200) return ValidD;


        WeatherForecastBll bll = new WeatherForecastBll(_configuration);

        return bll.DecryptPass(resqModel);
    }
}
