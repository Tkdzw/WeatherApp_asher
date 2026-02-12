namespace WeatherApp.Domain.Entities;

public class WeatherSnapshot
{
    public int Id { get; set; }

    public decimal Temperature { get; set; }

    public decimal FeelsLike { get; set; }

    public string Description { get; set; } = null!;

    public string Icon { get; set; } = null!;

    public int Humidity { get; set; }

    public decimal WindSpeed { get; set; }

    public DateTime Timestamp { get; set; }

    // Foreign Key
    public int LocationId { get; set; }

    // Navigation
    public Location Location { get; set; } = null!;
}
