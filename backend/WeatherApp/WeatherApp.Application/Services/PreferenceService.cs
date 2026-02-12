using Microsoft.EntityFrameworkCore;
using WeatherApp.Application.DTOs;
using WeatherApp.Application.Interfaces;
using WeatherApp.Infrastructure.Persistence;

public class PreferenceService : IPreferenceService
{
    private readonly AppDbContext _context;

    public PreferenceService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<PreferenceDto> GetPreferencesAsync(int userId)
    {
        var pref = await _context.UserPreferences
            .FirstOrDefaultAsync(x => x.UserId == userId);

        return new PreferenceDto
        {
            Units = pref.Units,
            RefreshIntervalMinutes = pref.RefreshIntervalMinutes
        };
    }

    public async Task UpdatePreferencesAsync(int userId, UpdatePreferenceRequest request)
    {
        var pref = await _context.UserPreferences
            .FirstOrDefaultAsync(x => x.UserId == userId);

        if (pref == null)
            throw new Exception("Preferences not found");

        pref.Units = request.Units;
        pref.RefreshIntervalMinutes = request.RefreshIntervalMinutes;

        await _context.SaveChangesAsync();
    }
}
