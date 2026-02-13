using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WeatherApp.Domain.Entities;

public class UserPreferenceConfiguration
    : IEntityTypeConfiguration<UserPreference>
{
    public void Configure(EntityTypeBuilder<UserPreference> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Units)
            .IsRequired()
            .HasMaxLength(20);

     

        // 🔗 1-1 Relationship
        builder.HasOne(x => x.User)
            .WithOne(u => u.Preference)
            .HasForeignKey<UserPreference>(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(x => x.UserId)
            .IsUnique(); // ensures 1-1
    }
}
