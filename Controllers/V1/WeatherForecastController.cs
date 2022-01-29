using hello_asp_localization.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace hello_asp_localization.Controllers.V1;

// namespace test;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly IStringLocalizer<WeatherForecastController> _localizer;

    private static readonly string[] Summaries = new[]
    {
        "WeatherConstantsFreezing", "WeatherConstantsBracing",
        "WeatherConstantsChilly", "WeatherConstantsCool",
        "WeatherConstantsMild", "WeatherConstantsWarm",
        "WeatherConstantsBalmy", "WeatherConstantsHot",
        "WeatherConstantsSweltering", "WeatherConstantsScorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(
        IStringLocalizer<WeatherForecastController> localizer,
        ILogger<WeatherForecastController> logger
    )
    {
        _localizer = localizer;
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        var weatherString = Summaries[Random.Shared.Next(Summaries.Length)];
        var localizerResult = _localizer["WeatherConstantsFreezing"];
        var location = localizerResult.SearchedLocation;
        var localizedString = localizerResult.Value;
        var found = localizerResult.ResourceNotFound;

        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            found = found,
            tmp = localizedString,
            Summary = location
        })
        .ToArray();
    }
}
