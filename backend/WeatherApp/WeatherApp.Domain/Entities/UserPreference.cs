namespace WeatherApp.Domain.Entities;

public class UserPreference
{
    public int Id { get; set; }

    public string Units { get; set; } = "metric"; // metric | imperial

    public int RefreshIntervalMinutes { get; set; } = 30;

    // Foreign Key
    public int UserId { get; set; }

    // Navigation
    public User User { get; set; } = null!;
}
