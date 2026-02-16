using AutoMapper;
using WeatherApp.Application.DTOs.Locations;
using WeatherApp.Domain.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class LocationProfile : Profile
{
    public LocationProfile()
    {
        CreateMap<Location, LocationDto>();

        CreateMap<UserLocation, LocationWithWeatherDto>()
            .ForMember(dest => dest.Id,
                opt => opt.MapFrom(src => src.Location.Id))
            .ForMember(dest => dest.City,
                opt => opt.MapFrom(src => src.Location.City))
            .ForMember(dest => dest.Country,
                opt => opt.MapFrom(src => src.Location.Country))
                     .ForMember(dest => dest.Weather,
                opt => opt.Ignore()); // set manually
    }
}
