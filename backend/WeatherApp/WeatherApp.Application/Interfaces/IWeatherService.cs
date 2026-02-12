using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Application.Interfaces
{
   public interface IWeatherService
{
    Task<WeatherDto> GetCurrentWeatherAsync(int locationId);

    Task<IEnumerable<ForecastDto>> GetForecastAsync(int locationId);

    Task SyncWeatherAsync(int locationId);

    Task SyncAllAsync(); // For background job
}
}
