namespace WeatherApp.Application.Interfaces
{
   public interface IPreferenceService
{
    Task<PreferenceDto> GetPreferencesAsync(int userId);

    Task UpdatePreferencesAsync(int userId, UpdatePreferenceRequest request);
}
}
