public class WeatherDto
{
    public decimal Temperature { get; set; }
    public decimal FeelsLike { get; set; }

    public string Description { get; set; }
    public string Icon { get; set; }

    public int Humidity { get; set; }
    public decimal WindSpeed { get; set; }

    public DateTime Timestamp { get; set; }
}
