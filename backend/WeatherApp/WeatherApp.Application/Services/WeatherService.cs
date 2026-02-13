using Microsoft.EntityFrameworkCore;
using WeatherApp.Application.DTOs;
using WeatherApp.Application.Interfaces;
using WeatherApp.Domain.Entities;
using WeatherApp.Infrastructure.Persistence;

public class WeatherService : IWeatherService
{
    private readonly AppDbContext _context;
    private readonly IWeatherApiClient _weatherApiClient;

    public WeatherService(
        AppDbContext context,
        IWeatherApiClient weatherApiClient)
    {
        _context = context;
        _weatherApiClient = weatherApiClient;
    }

    public async Task<WeatherDto> GetCurrentWeatherAsync(int locationId)
    {
        var snapshot = await _context.WeatherSnapshots
            .Where(x => x.LocationId == locationId)
            .OrderByDescending(x => x.Timestamp)
            .FirstOrDefaultAsync();

        if (snapshot == null)
            throw new Exception("Weather not synced yet");

        return new WeatherDto
        {
            Temperature = snapshot.Temperature,
            Description = snapshot.Description,
            Timestamp = snapshot.Timestamp
        };
    }

    public async Task SyncWeatherAsync(int locationId)
    {
        var location = await _context.Locations
            .FirstOrDefaultAsync(x => x.Id == locationId);

        if (location == null)
            throw new Exception("Location not found.");

        var preference = await _context.UserPreferences
            .FirstOrDefaultAsync(x => x.UserId == location.UserId);

        var units = preference?.Units ?? "metric";

        var weather = await _weatherApiClient
            .GetCurrentWeatherAsync(location.City, units);

        var snapshot = new WeatherSnapshot
        {
            LocationId = location.Id,
            Temperature = weather.Temperature,
            FeelsLike = weather.FeelsLike,
            Humidity = weather.Humidity,
            Icon = weather.City,
            Description = weather.Description,
            WindSpeed = weather.WindSpeed,
            Timestamp = DateTime.UtcNow
        };

        _context.WeatherSnapshots.Add(snapshot);
        location.LastSynced = DateTime.UtcNow;

        await _context.SaveChangesAsync();
    }


    public async Task<IEnumerable<ForecastDto>> GetForecastAsync(int locationId)
    {
        // You would map forecast response here
        return new List<ForecastDto>();
    }

    public async Task SyncAllAsync()
    {
        var locations = await _context.Locations.ToListAsync();

        foreach (var location in locations)
        {
            await SyncWeatherAsync(location.Id);
        }
    }
}
