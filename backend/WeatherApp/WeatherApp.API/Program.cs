using Microsoft.EntityFrameworkCore;
using WeatherApp.Application.Interfaces;
using WeatherApp.Application.Services;
using WeatherApp.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//MySql Configuration
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(
            builder.Configuration.GetConnectionString("DefaultConnection")
        )
    ));


builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<ILocationService, LocationService>();
builder.Services.AddTransient<IWeatherService, WeatherService>();
builder.Services.AddTransient<IPreferenceService, PreferenceService>();
builder.Services.AddScoped<IWeatherApiClient, OpenWeatherApiClient>();
builder.Services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();




builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
