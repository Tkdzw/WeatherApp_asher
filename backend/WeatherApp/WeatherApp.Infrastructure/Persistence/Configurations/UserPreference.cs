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

        builder.Property(x => x.RefreshIntervalMinutes)
            .IsRequired();
    }
}
