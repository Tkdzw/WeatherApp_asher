using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Application.Interfaces
{
    public interface IWeatherService
    {
        Task SyncWeatherAsync(int locationId);
        Task<IEnumerable<LocationDto>> GetAllLocationsAsync();
    }
}
