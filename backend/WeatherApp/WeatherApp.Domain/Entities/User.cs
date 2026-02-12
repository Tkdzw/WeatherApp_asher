namespace WeatherApp.Domain.Entities;

public class User
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    // Navigation Properties
    public UserPreference? Preference { get; set; }

    public ICollection<FavoriteLocation> FavoriteLocations { get; set; } 
        = new List<FavoriteLocation>();
}
