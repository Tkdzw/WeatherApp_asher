using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Application.DTOs.Weather;
using WeatherApp.Application.Interfaces;

namespace WeatherApp.Application.Services
{
    public class OpenWeatherApiClient : IWeatherApiClient
    {
        public Task<ExternalWeatherResponseDto> GetCurrentWeatherAsync(string city, string units)
        {
            throw new NotImplementedException();
        }

        public Task<ExternalForecastResponseDto> GetForecastAsync(string city, string units)
        {
            throw new NotImplementedException();
        }
    }
}
