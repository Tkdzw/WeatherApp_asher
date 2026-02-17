using WeatherApp.Application.DTOs.Weather;
using WeatherApp.Domain.Entities;

public class LocationDto
{
    public int Id { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public DateTime LastSynced { get; set; }


    public ICollection<WeatherSnapshotDto> WeatherSnapshots { get; set; }
}
        
