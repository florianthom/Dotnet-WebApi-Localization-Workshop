namespace hello_asp_localization.Domain;

public class WeatherForecast
{
    public DateTime Date { get; set; }

    public int TemperatureC { get; set; }

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    public bool found { get; set; }

    public string? tmp { get; set; }

    public string? Summary { get; set; }
}
