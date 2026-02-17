using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Application.DTOs.Locations;

namespace WeatherApp.Application.Interfaces
{
    public interface ILocationService
    {
        Task<IEnumerable<LocationDto>> GetAllAsync();

        Task<LocationDto?> GetByIdAsync(int id);

        Task<LocationDto> CreateAsync(CreateLocationRequest request);

        Task<UserLocationResponseDto> CreateUserLocationAsync(UserLocationDto request, int userId);

        Task UpdateAsync(int id, UpdateLocationRequest request);

        Task<List<LocationWithWeatherDto>> GetUserLocationsWithWeatherAsync(int userId);

        Task DeleteAsync(int id);
    }
}
