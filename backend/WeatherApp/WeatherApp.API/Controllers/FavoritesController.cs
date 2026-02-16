using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WeatherApp.Application.Interfaces;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class FavoritesController : ControllerBase
{
    private readonly IUserService _userService;

    public FavoritesController(IUserService userService)
    {
        _userService = userService;
    }

    private int GetUserId()
    {
        return int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
    }

    //[HttpGet]
    //public async Task<IActionResult> GetFavorites()
    //{
    //    var userId = GetUserId();
    //    var favorites = await _userService.GetFavoritesAsync(userId);
    //    return Ok(favorites);
    //}

    //[HttpPost("{locationId}")]
    //public async Task<IActionResult> AddFavorite(int locationId)
    //{
    //    var userId = GetUserId();
    //    await _userService.AddFavoriteAsync(userId, locationId);
    //    return NoContent();
    //}

    //[HttpDelete("{locationId}")]
    //public async Task<IActionResult> RemoveFavorite(int locationId)
    //{
    //    var userId = GetUserId();
    //    await _userService.RemoveFavoriteAsync(userId, locationId);
    //    return NoContent();
    //}
}
