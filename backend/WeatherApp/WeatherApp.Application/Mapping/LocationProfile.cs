using AutoMapper;
using WeatherApp.Application.DTOs.Locations;

public class LocationProfile : Profile
{
    public LocationProfile()
    {
        CreateMap<Location, LocationDto>()
                 .ForMember(dest => dest.WeatherSnapshots, opt => opt.MapFrom(src => src.WeatherSnapshots))
;

        CreateMap<UserLocation, LocationWithWeatherDto>()
            .ForMember(dest => dest.Id,
                opt => opt.MapFrom(src => src.Location.Id))
            .ForMember(dest => dest.City,
                opt => opt.MapFrom(src => src.Location.City))
            .ForMember(dest => dest.Country,
                opt => opt.MapFrom(src => src.Location.Country))
                     .ForMember(dest => dest.Weather,
                opt => opt.Ignore()); // set manually

        CreateMap<UserLocationDto, UserLocation>()
            .ForMember(dest => dest.LocationId,
                opt => opt.MapFrom(src => src.LocationId))
            .ForMember(dest => dest.IsFavourite,
                opt => opt.MapFrom(src => src.IsFavourite));
        
        CreateMap<UserLocation, UserLocationResponseDto>()
            .ForMember(dest => dest.LocationId,
                opt => opt.MapFrom(src => src.LocationId))
            .ForMember(dest => dest.LocationName,
                opt => opt.MapFrom(src => src.Location.City))
            .ForMember(dest => dest.IsFavourite,
                opt => opt.MapFrom(src => src.IsFavourite));
                  


        CreateMap<CreateLocationRequest, Location>()
            .ForMember(dest => dest.City,
                opt => opt.MapFrom(src => src.City))
            .ForMember(dest => dest.Country,
                opt => opt.MapFrom(src => src.Country));
            
    }
}
