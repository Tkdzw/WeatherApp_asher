using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class UserLocationConfiguration
    : IEntityTypeConfiguration<UserLocation>
{
    public void Configure(EntityTypeBuilder<UserLocation> builder)
    {
        builder.ToTable("UserLocations");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.IsFavourite)
            .IsRequired();

        builder.Property(x => x.CreatedAt)
            .IsRequired();

        // Many UserLocations → One User
        builder.HasOne(x => x.User)
            .WithMany(x => x.UserLocations)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // One UserLocation → One Location
        builder.HasOne(x => x.Location)
            .WithOne(x => x.UserLocation)
            .HasForeignKey<UserLocation>(x => x.LocationId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(x => new { x.UserId, x.LocationId })
            .IsUnique();
    }
}
