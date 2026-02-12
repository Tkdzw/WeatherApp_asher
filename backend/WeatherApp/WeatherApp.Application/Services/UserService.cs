using Microsoft.EntityFrameworkCore;
using BCrypt.Net;
using WeatherApp.Application.DTOs;
using WeatherApp.Application.DTOs.Auth;
using WeatherApp.Application.DTOs.Users;
using WeatherApp.Application.Interfaces;
using WeatherApp.Domain.Entities;
using WeatherApp.Infrastructure.Persistence;

public class UserService : IUserService
{
    private readonly AppDbContext _context;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public UserService(AppDbContext context, IJwtTokenGenerator jwtTokenGenerator)
    {
        _context = context;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<AuthResponseDto> RegisterAsync(RegisterRequestDto request)
    {
        if (await _context.Users.AnyAsync(x => x.Email == request.Email))
            throw new Exception("Email already exists");

        var user = new User
        {
            Username = request.Username,
            Email = request.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
            Preference = new UserPreference
            {
                Units = "metric",
                RefreshIntervalMinutes = 30
            }
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        var token = _jwtTokenGenerator.GenerateToken(user.Id, user.Email);

        return new AuthResponseDto
        {
            UserId = user.Id,
            Username = user.Username,
            Email = user.Email,
            Token = token
        };
    }

    public async Task<AuthResponseDto?> LoginAsync(LoginRequest request)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(x => x.Email == request.Email);

        if (user == null || 
            !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            return null;

        var token = _jwtTokenGenerator.GenerateToken(user.Id, user.Email);

        return new AuthResponseDto
        {
            UserId = user.Id,
            Username = user.Username,
            Email = user.Email,
            Token = token
        };
    }

    public async Task<IEnumerable<LocationDto>> GetFavoritesAsync(int userId)
    {
        return await _context.FavoriteLocations
            .Where(f => f.UserId == userId)
            .Select(f => new LocationDto
            {
                Id = f.Location.Id,
                City = f.Location.City,
                Country = f.Location.Country,
                Latitude = f.Location.Latitude,
                Longitude = f.Location.Longitude,
                LastSynced = f.Location.LastSynced
            })
            .ToListAsync();
    }

    public async Task AddFavoriteAsync(int userId, int locationId)
    {
        var exists = await _context.FavoriteLocations
            .AnyAsync(x => x.UserId == userId && x.LocationId == locationId);

        if (!exists)
        {
            _context.FavoriteLocations.Add(new FavoriteLocation
            {
                UserId = userId,
                LocationId = locationId,
                AddedAt = DateTime.UtcNow
            });

            await _context.SaveChangesAsync();
        }
    }


    public async Task<UserDto?> GetByIdAsync(int userId)
    {
        return await _context.Users
            .Where(x => x.Id == userId)
            .Select(x => new UserDto
            {
                Id = x.Id,
                Username = x.Username,
                Email = x.Email
            })
            .FirstOrDefaultAsync();
    }

 

    Task<UserDto?> IUserService.GetByIdAsync(int userId)
    {
        throw new NotImplementedException();
    }

    public Task RemoveFavoriteAsync(int userId, int locationId)
    {
        throw new NotImplementedException();
    }
}
