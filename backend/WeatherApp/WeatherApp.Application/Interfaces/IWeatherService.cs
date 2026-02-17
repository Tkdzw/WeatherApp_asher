using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Application.DTOs.Weather;

namespace WeatherApp.Application.Interfaces
{
    public interface IWeatherService
    {
        Task<List<UserLocationsWeatherDto>> GetUserLocationsWeather(int userId);
        Task<WeatherDto> GetCurrentWeatherAsync(int locationId);

        Task<ForecastDto> GetForecastAsync(int locationId);

        Task SyncWeatherAsync(int locationId);

        Task SyncAllAsync(); // For background job
    }
}
