using WeatherApp.Domain.Entities;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }

    public UserPreference Preference { get; set; }

    public ICollection<UserLocation> UserLocations { get; set; }
        = new List<UserLocation>();
}
