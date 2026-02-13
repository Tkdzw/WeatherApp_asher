using WeatherApp.Application.Models;
using WeatherForecast.DTOs;

namespace WeatherApp.Application.Interfaces
{
    public interface IWeatherApiClient
    {
        Task<ExternalWeatherResponse> GetCurrentWeatherAsync(
            string city,
            string units);

        Task<WeatherForecastResponseDto> GetForecastAsync(string city, string units);
    }

}
