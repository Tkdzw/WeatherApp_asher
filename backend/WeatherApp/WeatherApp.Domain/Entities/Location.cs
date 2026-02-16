using WeatherApp.Domain.Entities;

public class Location
{
    public int Id { get; set; }

    public string City { get; set; }
    public string Country { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }

    public DateTime LastSynced { get; set; }

    // 1:1 reverse navigation
    public UserLocation UserLocation { get; set; }

    public ICollection<WeatherSnapshot> WeatherSnapshots { get; set; }
        = new List<WeatherSnapshot>();

}
