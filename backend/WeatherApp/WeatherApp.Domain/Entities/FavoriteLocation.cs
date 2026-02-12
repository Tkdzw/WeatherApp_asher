
namespace WeatherApp.Domain.Entities
{
    public class FavoriteLocation
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int LocationId { get; set; }
        public Location Location { get; set; }

        public DateTime AddedAt { get; set; }
    }
}