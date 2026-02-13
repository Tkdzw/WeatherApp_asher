using System.Text.Json.Serialization;

namespace WeatherForecast.DTOs
{
    // Root DTO
    public class WeatherForecastResponseDto
    {
        public string Cod { get; set; }
        public int Message { get; set; }
        public int Cnt { get; set; }
        public List<ForecastItemDto> List { get; set; }
        public CityDto City { get; set; }
    }

    // Main Weather Data for each forecast period
    public class ForecastItemDto
    {
        public long Dt { get; set; }
        public MainWeatherDataDto Main { get; set; }
        public List<WeatherDescriptionDto> Weather { get; set; }
        public CloudsDto Clouds { get; set; }
        public WindDto Wind { get; set; }
        public int Visibility { get; set; }
        public double Pop { get; set; }
        public RainDto Rain { get; set; }
        public SysDto Sys { get; set; }
        public string Dt_Txt { get; set; }
    }

    // Main Weather Metrics
    public class MainWeatherDataDto
    {
        public double Temp { get; set; }
        public double FeelsLike { get; set; }
        public double TempMin { get; set; }
        public double TempMax { get; set; }
        public int Pressure { get; set; }
        public int SeaLevel { get; set; }
        public int GrndLevel { get; set; }
        public int Humidity { get; set; }
        public double TempKf { get; set; }
    }

    // Weather Description
    public class WeatherDescriptionDto
    {
        public int Id { get; set; }
        public string Main { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }

    // Clouds Information
    public class CloudsDto
    {
        public int All { get; set; }
    }

    // Wind Information
    public class WindDto
    {
        public double Speed { get; set; }
        public int Deg { get; set; }
        public double Gust { get; set; }
    }

    // Rain Information (optional, appears only when raining)
    public class RainDto
    {
        [JsonPropertyName("3h")]
        public double ThreeHour { get; set; }
    }

    // System Information
    public class SysDto
    {
        public string Pod { get; set; }
    }

    // City Information
    public class CityDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CoordinatesDto Coord { get; set; }
        public string Country { get; set; }
        public int Population { get; set; }
        public int Timezone { get; set; }
        public long Sunrise { get; set; }
        public long Sunset { get; set; }
    }

    // Coordinates
    public class CoordinatesDto
    {
        public double Lat { get; set; }
        public double Lon { get; set; }
    }
}