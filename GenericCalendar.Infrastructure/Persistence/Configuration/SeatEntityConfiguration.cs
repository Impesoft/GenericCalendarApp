using GenericCalendar.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GenericCalendar.Infrastructure.Persistence.Configuration;

public class SeatEntityConfiguration : IEntityTypeConfiguration<SeatEntity>
{
    public void Configure(EntityTypeBuilder<SeatEntity> builder)
    {
        builder.ToTable("Seats");

        builder.Property(s => s.Name).IsRequired().HasMaxLength(50);
        builder.Property(s => s.Row).IsRequired().HasMaxLength(10);
        builder.Property(s => s.Number).IsRequired();

        builder.HasIndex(s => new { s.Row, s.Number }).IsUnique();

    }
}
