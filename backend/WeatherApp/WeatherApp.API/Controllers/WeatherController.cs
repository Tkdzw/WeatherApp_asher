using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using WeatherApp.Application.Interfaces;

[EnableRateLimiting("FixedPolicy")]
[ApiController]
[Authorize]
[Route("api/[controller]")]
public class WeatherController : ControllerBase
{
    private readonly IWeatherService _weatherService;

    public WeatherController(IWeatherService weatherService)
    {
        _weatherService = weatherService;
    }

    [HttpGet("{locationId}")]
    public async Task<IActionResult> GetCurrentWeather(int locationId)
    {
        var weather = await _weatherService.GetCurrentWeatherAsync(locationId);
        return Ok(weather);
    }

    [HttpGet("{locationId}/forecast")]
    public async Task<IActionResult> GetForecast(int locationId)
    {
        var forecast = await _weatherService.GetForecastAsync(locationId);
        return Ok(forecast);
    }

    [HttpPost("{locationId}/sync")]
    public async Task<IActionResult> SyncWeather(int locationId)
    {
        await _weatherService.SyncWeatherAsync(locationId);
        return NoContent();
    }
}
