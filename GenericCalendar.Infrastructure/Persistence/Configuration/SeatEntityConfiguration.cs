using GenericCalendar.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GenericCalendar.Infrastructure.Persistence.Configuration;

public class SeatEntityConfiguration : IEntityTypeConfiguration<SeatEntity>
{
    public void Configure(EntityTypeBuilder<SeatEntity> builder)
    {
        builder.ToTable("Seats");

        // Configure inherited properties from BaseSeatEntity
        builder.Property(s => s.Row).IsRequired().HasMaxLength(10);
        builder.Property(s => s.Number).IsRequired();

        // Configure properties from BookableItemEntity
        builder.Property(s => s.Name).IsRequired().HasMaxLength(50);

        // Add unique index for Row and Number
        builder.HasIndex(s => new { s.Row, s.Number }).IsUnique();
    }
}
