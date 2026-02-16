using AutoMapper;
using WeatherApp.Domain.Entities;
using WeatherApp.Infrastructure.External.OpenWeather;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class ExternalWeatherProfile : Profile
{
    public ExternalWeatherProfile()
    {
        //CreateMap<OpenWeatherResponse, WeatherSnapshot>()
        //    .ForMember(dest => dest.Temperature,
        //        opt => opt.MapFrom(src => src.Main.Temp))
        //    .ForMember(dest => dest.FeelsLike,
        //        opt => opt.MapFrom(src => src.Main.Feels_Like))
        //    .ForMember(dest => dest.Humidity,
        //        opt => opt.MapFrom(src => src.Main.Humidity))
        //    .ForMember(dest => dest.Description,
        //        opt => opt.MapFrom(src => src.Weather.FirstOrDefault().Description))
        //    .ForMember(dest => dest.Icon,
        //        opt => opt.MapFrom(src => src.Weather.FirstOrDefault().Icon))
        //    .ForMember(dest => dest.WindSpeed,
        //        opt => opt.MapFrom(src => src.Wind.Speed))
        //    .ForMember(dest => dest.Timestamp,
        //        opt => opt.MapFrom(_ => DateTime.UtcNow));
    }
}
