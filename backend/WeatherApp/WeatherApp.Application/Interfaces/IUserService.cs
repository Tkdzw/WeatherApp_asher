namespace WeatherApp.Application.Interfaces
{
   public interface IUserService
{
    Task<AuthResponseDto> RegisterAsync(RegisterRequest request);
    Task<AuthResponseDto?> LoginAsync(LoginRequest request);

    Task<UserDto?> GetByIdAsync(int userId);

    Task<IEnumerable<LocationDto>> GetFavoritesAsync(int userId);
    Task AddFavoriteAsync(int userId, int locationId);
    Task RemoveFavoriteAsync(int userId, int locationId);
}
}
