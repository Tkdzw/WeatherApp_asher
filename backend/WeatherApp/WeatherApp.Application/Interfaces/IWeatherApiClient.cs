using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Application.Interfaces
{
    public interface IWeatherApiClient
{
    Task<ExternalWeatherResponse> GetCurrentWeatherAsync(
        string city,
        string units);

    Task<ExternalForecastResponse> GetForecastAsync(
        string city,
        string units);
}

}
