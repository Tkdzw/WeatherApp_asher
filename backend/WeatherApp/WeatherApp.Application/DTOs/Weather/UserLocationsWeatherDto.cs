namespace WeatherApp.Application.DTOs.Weather
{
    public class UserLocationsWeatherDto
    {
        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public bool IsFavourite { get; set; } = false;

        public LocationDto Location { get; set; }

        public WeatherSnapshotDto WeatherSnapshot { get; set; }
    }
}
