using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using System.Text.Json;
using WeatherApp.Application.DTOs;
using WeatherApp.Application.DTOs.Weather;
using WeatherApp.Application.Interfaces;
using WeatherApp.Domain.Entities;
using WeatherApp.Infrastructure.Persistence;
using WeatherForecast.DTOs;
using static WeatherService;

public class WeatherService : IWeatherService
{
    private readonly AppDbContext _context;
    private readonly IWeatherApiClient _weatherApiClient;
    private readonly IMapper _mapper;

    public WeatherService(
        AppDbContext context,
        IMapper mapper,
        IWeatherApiClient weatherApiClient)
    {
        _context = context;
        _weatherApiClient = weatherApiClient;
        _mapper = mapper;
    }


    public async Task<List<UserLocationsWeatherDto>> GetUserLocationsWeather(int userId)
    {
        var userweatherEntity = await _context.UserLocations
            .Where(l => l.UserId == userId)
            .Include(l => l.Location)
            .ThenInclude(s => s.WeatherSnapshots)
            .ToListAsync();

        var userWeather = _mapper.Map<List<UserLocationsWeatherDto>>(userweatherEntity);

        return userWeather;
    }

    //Pass location get current weather for the location
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



    // Background Service
    //Update Weathersnapshots in the database.
    public async Task SyncWeatherAsync(int locationId)
    {
        var location = await _context.Locations
            .FirstOrDefaultAsync(x => x.Id == locationId);

        if (location == null)
            throw new Exception("Location not found.");

        //var preference = await _context.UserPreferences
        //    .FirstOrDefaultAsync(x => x.UserId == location.UserId);

        //var units = preference?.Units ?? "metric";
        var units = "metric";

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


    //Background Or On Request
    // Get Weatherforecast one for each day.
    //Adjusted to show one for each (to revert and manage the response)
    public async Task<ForecastDto> GetForecastAsync(int locationId)
    {

        var location = await _context.Locations
           .FirstOrDefaultAsync(x => x.Id == locationId);

        if (location == null)
            throw new Exception("Location not found.");

        //var preference = await _context.UserPreferences
        //    .FirstOrDefaultAsync(x => x.UserId == location.UserId);

        //var units = preference?.Units ?? "metric";
        var units = "metric";

        var forecastResponse = await _weatherApiClient
            .GetForecastAsync(location.City, units);

        ForecastDto dto = MapToForecastDto(forecastResponse ?? throw new ApplicationException("Failed to deserialize response"));
        return dto;
    }


    //Background Service
    public async Task SyncAllAsync()
    {
        var locations = await _context.Locations.ToListAsync();

        foreach (var location in locations)
        {
            await SyncWeatherAsync(location.Id);
        }
    }


    // MAPPING METHOD
    //Limited to one per day for assessment
    public ForecastDto MapToForecastDto(WeatherForecastResponseDto forecastData)
    {
        return new ForecastDto
        {
            City = forecastData.City?.Name,
            Country = forecastData.City?.Country,
            Lat = forecastData.City?.Coord?.Lat ?? 0,
            Lon = forecastData.City?.Coord?.Lon ?? 0,
            Daily = forecastData.List?
                .Where(item => item?.Main != null && !string.IsNullOrEmpty(item.Dt_Txt))
                .Select(item =>
                {
                    DateTime.TryParse(item.Dt_Txt, out var parsedDate);
                    return new
                    {
                        Date = parsedDate.Date,
                        FullItem = item,
                        Hour = parsedDate.Hour
                    };
                })
                // Group by date
                .GroupBy(x => x.Date)
                // For each date, take the forecast around midday (12:00)
                .Select(g =>
                {
                    // Try to get the 12:00 forecast first
                    var middayForecast = g.FirstOrDefault(x => x.Hour == 12);
                    // If no 12:00 forecast, take the closest to midday
                    var selected = middayForecast ?? g.OrderBy(x => Math.Abs(x.Hour - 12)).First();

                    var item = selected.FullItem;

                    return new DailyForecastDto
                    {
                        Date = selected.Date,
                        Day = selected.Date.ToString("ddd"),
                        Temp = Math.Round(item.Main.Temp, 1),
                        TempMin = Math.Round(item.Main.TempMin, 1),
                        TempMax = Math.Round(item.Main.TempMax, 1),
                        FeelsLike = Math.Round(item.Main.FeelsLike, 1),
                        Humidity = item.Main.Humidity,
                        Weather = item.Weather?.FirstOrDefault()?.Main ?? "Unknown",
                        Description = item.Weather?.FirstOrDefault()?.Description ?? "Unknown",
                        Icon = item.Weather?.FirstOrDefault()?.Icon ?? "01d",
                        WindSpeed = item.Wind?.Speed ?? 0,
                        Rain = item.Rain?.ThreeHour ?? 0,
                        Clouds = item.Clouds?.All ?? 0
                    };
                })
                .OrderBy(d => d.Date)
                .ToList() ?? new List<DailyForecastDto>()
        };
    }






}
