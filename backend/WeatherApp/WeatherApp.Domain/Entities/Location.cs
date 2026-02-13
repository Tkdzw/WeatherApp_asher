namespace WeatherApp.Domain.Entities;

public class Location
{
    public int Id { get; set; }

    public string City { get; set; } = null!;

    public string Country { get; set; } = null!;

    public double Latitude { get; set; }

    public double Longitude { get; set; }

    public DateTime LastSynced { get; set; }

    // Navigation

    public int UserId { get; set; }
    public ICollection<WeatherSnapshot> WeatherSnapshots { get; set; }
        = new List<WeatherSnapshot>();

    public ICollection<FavoriteLocation> FavoritedByUsers { get; set; }
        = new List<FavoriteLocation>();
}
