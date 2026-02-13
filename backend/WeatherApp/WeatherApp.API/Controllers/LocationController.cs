using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WeatherApp.Application.Interfaces;

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

    [HttpPost]
    public async Task<IActionResult> Create(CreateLocationRequest request)
    {
        var location = await _locationService.CreateAsync(request);
        return CreatedAtAction(nameof(Get), new { id = location.Id }, location);
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
