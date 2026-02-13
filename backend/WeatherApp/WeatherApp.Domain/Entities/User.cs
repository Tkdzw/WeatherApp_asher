namespace WeatherApp.Domain.Entities;


public class User
{
    public int Id { get; set; }

    public string Username { get; set; }

    public string Email { get; set; } = string.Empty;

    public string PasswordHash { get; set; } = string.Empty;

    // 🔗 One-to-one relationship
    public UserPreference Preference { get; set; } = null!;

    public ICollection<Location> Locations { get; set; }
        = new List<Location>();
    public ICollection<FavoriteLocation> FavoriteLocations { get; set; }
        = new List<FavoriteLocation>();
}

