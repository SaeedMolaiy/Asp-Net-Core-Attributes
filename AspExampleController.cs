using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace AspAttributes.Controllers;

[ApiController]
[AutoValidateAntiforgeryToken]
[Route("[controller]")]
public class AspExampleController : ControllerBase
{
    private static readonly string[] Summaries =
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<AspExampleController> _logger;

    public AspExampleController(ILogger<AspExampleController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    [HttpPost]
    [HttpPut]
    [HttpDelete]
    [Consumes("application/json")]
    [Produces("application/json")]
    [Authorize(Policy = "Policy")]
    [ValidateAntiForgeryToken]
    [EnableCors(PolicyName = "Cors")]
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
}