using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WeatherApp.Application.Interfaces;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IPreferenceService _preferenceService;

    public UsersController(IPreferenceService preferenceService)
    {
        _preferenceService = preferenceService;
    }

    private int GetUserId()
    {
        return int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
    }

    [HttpGet("preferences")]
    public async Task<IActionResult> GetPreferences()
    {
        var userId = GetUserId();
        var preferences = await _preferenceService.GetPreferencesAsync(userId);
        return Ok(preferences);
    }

    [HttpPut("preferences")]
    public async Task<IActionResult> UpdatePreferences(UpdatePreferenceRequest request)
    {
        var userId = GetUserId();
        await _preferenceService.UpdatePreferencesAsync(userId, request);
        return NoContent();
    }
}
