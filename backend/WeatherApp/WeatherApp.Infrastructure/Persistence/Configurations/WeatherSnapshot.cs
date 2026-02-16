using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WeatherApp.Domain.Entities;

public class WeatherSnapshotConfiguration
    : IEntityTypeConfiguration<WeatherSnapshot>
{
    public void Configure(EntityTypeBuilder<WeatherSnapshot> builder)
    {
        builder.ToTable("WeatherSnapshots");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Temperature)
            .IsRequired();

        builder.Property(x => x.FeelsLike)
            .IsRequired();

        builder.Property(x => x.Description)
            .HasMaxLength(250);

        builder.Property(x => x.Icon)
            .HasMaxLength(50);

        builder.Property(x => x.Humidity)
            .IsRequired();

        builder.Property(x => x.WindSpeed)
            .IsRequired();

        builder.Property(x => x.Timestamp)
            .IsRequired();

        builder.HasIndex(x => x.LocationId);
        builder.HasIndex(x => x.Timestamp);
    }
}
