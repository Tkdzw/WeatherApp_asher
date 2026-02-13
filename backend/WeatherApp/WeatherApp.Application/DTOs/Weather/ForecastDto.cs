public class ForecastDto
{
    public string City { get; set; }
    public string Country { get; set; }
    public double Lat { get; set; }
    public double Lon { get; set; }
    public List<DailyForecastDto> Daily { get; set; }
}

public class DailyForecastDto
{
    public DateTime Date { get; set; }
    public string Day { get; set; }
    public double Temp { get; set; }
    public double TempMin { get; set; }
    public double TempMax { get; set; }
    public double FeelsLike { get; set; }
    public int Humidity { get; set; }
    public string Weather { get; set; }
    public string Description { get; set; }
    public string Icon { get; set; }
    public double WindSpeed { get; set; }
    public double Rain { get; set; }
    public int Clouds { get; set; }
}