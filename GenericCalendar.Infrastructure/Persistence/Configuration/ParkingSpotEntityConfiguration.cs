using GenericCalendar.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GenericCalendar.Infrastructure.Persistence.Configuration;

public class ParkingSpotEntityConfiguration : IEntityTypeConfiguration<ParkingSpotEntity>
{
    public void Configure(EntityTypeBuilder<ParkingSpotEntity> builder)
    {
        builder.ToTable("ParkingSpots");

        builder.Property(p => p.SpotNumber).IsRequired();
        builder.Property(p => p.Level).IsRequired().HasMaxLength(50);
        builder.Property(p => p.IsCovered).IsRequired();

        builder.HasIndex(p => new { p.Level, p.SpotNumber }).IsUnique();
    }
}
