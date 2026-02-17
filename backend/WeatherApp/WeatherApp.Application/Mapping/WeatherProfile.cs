using AutoMapper;
using WeatherApp.Application.DTOs.Locations;
using WeatherApp.Application.DTOs.Weather;
using WeatherApp.Domain.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class WeatherProfile : Profile
{
    public WeatherProfile()
    {
        CreateMap<WeatherSnapshot, WeatherDto>();

        CreateMap<UserLocation, UserLocationsWeatherDto>()
            .ForMember(dest => dest.LocationId, opt=> opt.MapFrom(src => src.Location.Id))
            .ForMember(dest => dest.WeatherSnapshots, opt=> opt.MapFrom(src => src.Location.WeatherSnapshots))
            .ForMember(dest => dest.LocationName, opt=> opt.MapFrom(src => src.Location));

        CreateMap<WeatherSnapshot, WeatherSnapshotDto>();
    }
}
