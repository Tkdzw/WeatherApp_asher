using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using WeatherApp.Infrastructure.Persistence;

public class AppDbContextFactory
    : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

        optionsBuilder.UseMySql(
            "server=localhost;port=3306;database=weatherapp;user=root;password=PasswordUnhackable;",
            ServerVersion.AutoDetect("server=localhost;port=3306;database=weatherapp;user=root;password=PasswordUnhackable;")
        );

        return new AppDbContext(optionsBuilder.Options);
    }
}
