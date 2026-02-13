using Microsoft.Extensions.Configuration;
using System.Net.Http.Json;
using System.Text.Json;
using WeatherApp.Application.Interfaces;
using WeatherApp.Application.Models;
using WeatherApp.Infrastructure.External.OpenWeather.Models;
using WeatherForecast.DTOs;
using static System.Net.WebRequestMethods;

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
        string units)
    {
        var apiKey = _configuration["OpenWeather:ApiKey"];
        var baseUrl = _configuration["OpenWeather:BaseUrl"];

      

        var requestUrl = $"{baseUrl}/weather?q={city}&appid={apiKey}&units={units}";

        var response = await _httpClient.GetAsync(requestUrl);

        if (!response.IsSuccessStatusCode)
        {
            throw new ApplicationException(
                $"OpenWeather API error: {response.StatusCode}");
        }

        var raw = await response.Content
            .ReadFromJsonAsync<OpenWeatherRawResponse>();

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

    public async Task<WeatherForecastResponseDto> GetForecastAsync(string city, string units)
    {
        var apiKey = _configuration["OpenWeather:ApiKey"];
        var baseUrl = _configuration["OpenWeather:BaseUrl"];

        var requestUrl = $"{baseUrl}/forecast?q={city}&units={units}&appid={apiKey}";

        var response = await _httpClient.GetAsync(requestUrl);

        if (!response.IsSuccessStatusCode)
        {
            var errorContent = await response.Content.ReadAsStringAsync();
            throw new HttpRequestException(
                $"OpenWeather API returned {response.StatusCode}: {errorContent}");
        }

        var forecastData = await response.Content
            .ReadFromJsonAsync<WeatherForecastResponseDto>();

        return forecastData ?? throw new ApplicationException("Failed to deserialize response");
    }




}
