using AutoMapper;
using WeatherApp.Application.DTOs.Locations;
using WeatherApp.Domain.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class WeatherProfile : Profile
{
    public WeatherProfile()
    {
        CreateMap<WeatherSnapshot, WeatherDto>();
    }
}
