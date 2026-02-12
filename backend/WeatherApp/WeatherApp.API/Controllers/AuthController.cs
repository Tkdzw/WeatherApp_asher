using Microsoft.AspNetCore.Mvc;
using WeatherApp.Application.DTOs.Auth;
using WeatherApp.Application.Interfaces;


[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;

    public AuthController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequestDto request)
    {
        var result = await _userService.RegisterAsync(request);
        return Ok(result);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var result = await _userService.LoginAsync(request);

        if (result == null)
            return Unauthorized("Invalid credentials");

        return Ok(result);
    }
}
