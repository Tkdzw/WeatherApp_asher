using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Application.Interfaces
{
   public interface ILocationService
{
    Task<IEnumerable<LocationDto>> GetAllAsync();

    Task<LocationDto?> GetByIdAsync(int id);

    Task<LocationDto> CreateAsync(CreateLocationRequest request);

    Task UpdateAsync(int id, UpdateLocationRequest request);

    Task DeleteAsync(int id);
}
}
