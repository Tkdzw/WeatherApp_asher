using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WeatherApp.Domain.Entities;

public class WeatherSnapshotConfiguration 
    : IEntityTypeConfiguration<WeatherSnapshot>
{
    public void Configure(EntityTypeBuilder<WeatherSnapshot> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Temperature)
            .HasColumnType("decimal(8,2)");

        builder.Property(x => x.FeelsLike)
            .HasColumnType("decimal(8,2)");

        builder.Property(x => x.Description)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(x => x.Icon)
            .HasMaxLength(50);

        builder.Property(x => x.WindSpeed)
            .HasColumnType("decimal(8,2)");

        builder.Property(x => x.Timestamp)
            .IsRequired();

        builder.HasOne(x => x.Location)
            .WithMany(x => x.WeatherSnapshots)
            .HasForeignKey(x => x.LocationId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(x => x.Timestamp);
    }
}
