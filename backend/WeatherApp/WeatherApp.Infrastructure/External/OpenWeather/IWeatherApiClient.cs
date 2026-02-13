using WeatherApp.Application.Models;

namespace WeatherApp.Application.Interfaces
{
    public interface IWeatherApiClient
    {
        Task<ExternalWeatherResponse> GetCurrentWeatherAsync(
            string city,
            string units);

        //Task<ExternalForecastResponseDto> GetForecastAsync(
        //    string city,
        //    string units);
    }

}
