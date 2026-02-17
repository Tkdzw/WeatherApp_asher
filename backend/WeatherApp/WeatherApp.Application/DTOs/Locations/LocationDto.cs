using WeatherApp.Domain.Entities;

public class LocationDto
{
    public int Id { get; set; }
    public string City { get; set; }
    public string Country { get; set; }

    public double Latitude { get; set; }
    public double Longitude { get; set; }

    public DateTime LastSynced { get; set; }

    //public WeatherDto? CurrentWeather { get; set; }

    public bool IsFavorite { get; set; }

    public ICollection<WeatherSnapshot> WeatherSnapshots { get; set; }
        = new List<WeatherSnapshot>();
}
