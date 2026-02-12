using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Application.DTOs.Weather;

namespace WeatherApp.Application.Interfaces
{
    public interface IWeatherApiClient
    {
        Task<ExternalWeatherResponseDto> GetCurrentWeatherAsync(
            string city,
            string units);

        Task<ExternalForecastResponseDto> GetForecastAsync(
            string city,
            string units);
    }

}
