using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WeatherApp.Application.DTOs;
using WeatherApp.Application.DTOs.Locations;
using WeatherApp.Application.Interfaces;
using WeatherApp.Domain.Entities;
using WeatherApp.Infrastructure.Persistence;

public class LocationService : ILocationService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public LocationService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<LocationDto>> GetAllAsync()
    {
        return await _context.Locations
            .Select(l => new LocationDto
            {
                Id = l.Id,
                City = l.City,
                Country = l.Country,
                Latitude = l.Latitude,
                Longitude = l.Longitude,
                LastSynced = l.LastSynced
            })
            .ToListAsync();
    }


    public async Task<LocationDto> CreateAsync(CreateLocationRequest request)
    {


        //var userExists = await _context.Users
        //   .AnyAsync(u => u.Id == userId);

        //if (!userExists)
        //    throw new Exception("User does not exist.");

        //var location = new Location
        //{
        //    City = request.City,
        //    Country = request.Country,
        //    LastSynced = DateTime.UtcNow,
        //};

        var location = _mapper.Map<Location>(request);

       var entity =  _context.Locations.Add(location);
        await _context.SaveChangesAsync();



        return new LocationDto
        {
            Id = location.Id,
            City = location.City,
            Country = location.Country,
            LastSynced = location.LastSynced
        };
    }

    public async Task<List<LocationWithWeatherDto>>
    GetUserLocationsWithWeatherAsync(int userId)
    {
        var locations = await _context.UserLocations
            .Include(l => l.Location)
            .ThenInclude(loc => loc.WeatherSnapshots)
            .ToListAsync();

        
        
        var result = locations.Select(ul =>
        {
            var l = ul.Location;
            var latestWeather = l.WeatherSnapshots
                .OrderByDescending(w => w.Timestamp)
                .FirstOrDefault();
            return new LocationWithWeatherDto
            {
                Id = l.Id,
                City = l.City,
                Country = l.Country,
                Weather = latestWeather == null ? null : new WeatherDto
                {
                    Temperature = latestWeather.Temperature,
                    Description = latestWeather.Description,
                    Timestamp = latestWeather.Timestamp
                }
            };
        }).ToList();

        //var result = locations.Select(l =>
        //{
        //    var latestWeather = l.WeatherSnapshots
        //        .OrderByDescending(w => w.Timestamp)
        //        .FirstOrDefault();

        //    return new LocationWithWeatherDto
        //    {
        //        Id = l.Id,
        //        City = l.City,
        //        Country = l.Country,
        //        Weather = latestWeather == null ? null : new WeatherDto
        //        {
        //            Temperature = latestWeather.Temperature,
        //            Description = latestWeather.Description,
        //            Timestamp = latestWeather.Timestamp
        //        }
        //    };
        //}).ToList();

        return result;
    }

    public async Task UpdateAsync(int id, UpdateLocationRequest request)
    {
        var location = await _context.Locations.FindAsync(id);
        if (location == null)
            throw new Exception("Location not found");

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var location = await _context.Locations.FindAsync(id);
        if (location == null)
            throw new Exception("Location not found");

        _context.Locations.Remove(location);
        await _context.SaveChangesAsync();
    }

    public Task<LocationDto?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<UserLocationResponseDto> CreateUserLocationAsync(UserLocationDto request, int userId)
    {
        var userLocation = _mapper.Map<UserLocation>(request);

        userLocation.UserId = userId;

        _context.Add(userLocation);
        await _context.SaveChangesAsync();

        var entity = await _context.UserLocations
            .Where(ul => ul.UserId == userId && ul.LocationId == userLocation.LocationId)
            .Include(l => l.Location)
            .FirstOrDefaultAsync();

        var result = _mapper.Map<UserLocationResponseDto>(entity);
        return result;
    }
}
