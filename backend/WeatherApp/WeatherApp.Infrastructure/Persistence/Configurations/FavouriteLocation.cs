using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WeatherApp.Domain.Entities;

public class FavoriteLocationConfiguration
    : IEntityTypeConfiguration<FavoriteLocation>
{
    public void Configure(EntityTypeBuilder<FavoriteLocation> builder)
    {
        // 🔥 THIS IS THE IMPORTANT PART
        builder.HasKey(x => new { x.UserId, x.LocationId });

        builder.Property(x => x.AddedAt)
            .IsRequired();

        builder.HasOne(x => x.User)
            .WithMany(x => x.FavoriteLocations)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Location)
            .WithMany(x => x.FavoritedByUsers)
            .HasForeignKey(x => x.LocationId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
