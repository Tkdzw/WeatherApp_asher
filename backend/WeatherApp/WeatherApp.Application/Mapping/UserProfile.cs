using AutoMapper;
using WeatherApp.Application.DTOs.Auth;
using WeatherApp.Domain.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, AuthResponseDto>()
            .ForMember(dest => dest.UserId,
                       opt => opt.MapFrom(src => src.Id));

        CreateMap<RegisterRequestDto, User>()
            .ForMember(dest => dest.PasswordHash,
                       opt => opt.MapFrom(src => src.Password))
            .ForMember(dest => dest.Preference,
                       opt => opt.MapFrom(src => new UserPreference
                       {
                           Units = "metric",
                           RefreshIntervalMinutes = 30
                       }));
    }
}
