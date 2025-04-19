using GenericCalendar.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GenericCalendar.Infrastructure.Persistence.Configuration;

public class FlightSeatEntityConfiguration : IEntityTypeConfiguration<FlightSeatEntity>
{
    public void Configure(EntityTypeBuilder<FlightSeatEntity> builder)
    {
        builder.ToTable("FlightSeats");

        // Configure inherited properties from BaseSeatEntity
        builder.Property(f => f.Row).IsRequired().HasMaxLength(10);
        builder.Property(f => f.Number).IsRequired();

        // Configure additional properties specific to FlightSeatEntity
        builder.Property(f => f.FlightNumber).IsRequired().HasMaxLength(20);
        builder.Property(f => f.SeatClass).IsRequired().HasMaxLength(20);

        // Add unique index for FlightNumber, Row, and Number
        builder.HasIndex(f => new { f.FlightNumber, f.Row, f.Number }).IsUnique();
    }
}
