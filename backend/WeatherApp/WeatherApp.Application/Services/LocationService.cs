using Microsoft.EntityFrameworkCore;
using WeatherApp.Application.DTOs;
using WeatherApp.Application.Interfaces;
using WeatherApp.Domain.Entities;
using WeatherApp.Infrastructure.Persistence;

public class LocationService : ILocationService
{
    private readonly AppDbContext _context;

    public LocationService(AppDbContext context)
    {
        _context = context;
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


        var location = new Location
        {
            City = request.City,
            Country = request.Country,
            LastSynced = DateTime.UtcNow
        };

        _context.Locations.Add(location);
        await _context.SaveChangesAsync();

        return new LocationDto
        {
            Id = location.Id,
            City = location.City,
            Country = location.Country
        };
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
}
