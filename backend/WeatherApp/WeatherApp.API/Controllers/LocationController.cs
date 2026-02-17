using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using System.Security.Claims;
using WeatherApp.Application.DTOs.Locations;
using WeatherApp.Application.Interfaces;

[EnableRateLimiting("FixedPolicy")]
[ApiController]
[Authorize]
[Route("api/weather/[controller]")]
public class LocationsController : ControllerBase
{
    private readonly ILocationService _locationService;

    public LocationsController(ILocationService locationService)
    {
        _locationService = locationService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var locations = await _locationService.GetAllAsync();
        return Ok(locations);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var location = await _locationService.GetByIdAsync(id);
        if (location == null)
            return NotFound();

        return Ok(location);
    }


    [HttpGet("with-weather")]
    public async Task<IActionResult> GetUserLocations()
    {
        var userId = int.Parse(
            User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

        var result = await _locationService
            .GetUserLocationsWithWeatherAsync(userId);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateLocationRequest request)
    {
        var userId = int.Parse(
            User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        var location = await _locationService.CreateAsync(request);
        return CreatedAtAction(nameof(Get), new { id = location.Id }, location);
    }

    [HttpPost("userlocation")]
    public async Task<IActionResult> CreateUserLocation(UserLocationDto userLocation)
    {
        var userId = int.Parse(
           User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        var result = await _locationService.CreateUserLocationAsync(userLocation,userId);

        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateLocationRequest request)
    {
        await _locationService.UpdateAsync(id, request);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _locationService.DeleteAsync(id);
        return NoContent();
    }
}
