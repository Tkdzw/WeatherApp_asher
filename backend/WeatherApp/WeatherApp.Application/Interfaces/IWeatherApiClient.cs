using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Application.DTOs.Weather;
using WeatherApp.Application.Models;

namespace WeatherApp.Application.Interfaces
{
    public interface IWeatherApiClient
    {
        Task<ExternalWeatherResponse> GetCurrentWeatherAsync(
            string city,
            string units);

        Task<ExternalForecastResponseDto> GetForecastAsync(
            string city,
            string units);
    }

}
