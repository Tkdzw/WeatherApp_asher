using System.Net.Http.Json;
using Microsoft.Extensions.Configuration;
using WeatherApp.Application.Interfaces;
using WeatherApp.Application.Models;
using WeatherApp.Infrastructure.External.OpenWeather.Models;

namespace WeatherApp.Infrastructure.External.OpenWeather;

public class OpenWeatherApiClient : IWeatherApiClient
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public OpenWeatherApiClient(
        HttpClient httpClient,
        IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }

    public async Task<ExternalWeatherResponse> GetCurrentWeatherAsync(
        string city,
        string units,
        CancellationToken cancellationToken = default)
    {
        var apiKey = _configuration["OpenWeather:ApiKey"];
        var baseUrl = _configuration["OpenWeather:BaseUrl"];

        var requestUrl = $"{baseUrl}/weather?q={city}&appid={apiKey}&units={units}";

        var response = await _httpClient.GetAsync(requestUrl, cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            throw new ApplicationException(
                $"OpenWeather API error: {response.StatusCode}");
        }

        var raw = await response.Content
            .ReadFromJsonAsync<OpenWeatherRawResponse>(cancellationToken: cancellationToken);

        if (raw == null)
            throw new ApplicationException("Failed to deserialize weather response.");

        return MapToExternalResponse(raw);
    }

    private static ExternalWeatherResponse MapToExternalResponse(
        OpenWeatherRawResponse raw)
    {
        return new ExternalWeatherResponse
        {
            City = raw.Name,
            Temperature = raw.Main.Temp,
            FeelsLike = raw.Main.FeelsLike,
            Humidity = raw.Main.Humidity,
            Description = raw.Weather.FirstOrDefault()?.Description ?? "",
            WindSpeed = raw.Wind.Speed
        };
    }
}
