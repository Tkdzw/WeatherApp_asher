namespace WeatherApp.Domain.Entities;

public class WeatherSnapshot
{
    public int Id { get; set; }

    public double Temperature { get; set; }

    public double FeelsLike { get; set; }

    public string Description { get; set; } = null!;

    public string Icon { get; set; } = null!;

    public int Humidity { get; set; }

    public double WindSpeed { get; set; }

    public DateTime Timestamp { get; set; }

    // Foreign Key
    public int LocationId { get; set; }

    // Navigation
    public Location Location { get; set; } = null!;
}
