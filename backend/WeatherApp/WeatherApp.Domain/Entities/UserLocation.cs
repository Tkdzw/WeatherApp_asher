using WeatherApp.Domain.Entities;

public class UserLocation
{
    public int Id { get; set; }

    // FK to User (One User → Many UserLocations)
    public int UserId { get; set; }
    public User User { get; set; }

    // FK to Location (One-to-One)
    public int LocationId { get; set; }
    public Location Location { get; set; }

    public bool IsFavourite { get; set; } = false;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
