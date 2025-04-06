using GenericCalendar.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GenericCalendar.Infrastructure.Persistence.Configuration;

public class RoomEntityConfiguration : IEntityTypeConfiguration<RoomEntity>
{
    public void Configure(EntityTypeBuilder<RoomEntity> builder)
    {
        builder.ToTable("Rooms");

        builder.Property(r => r.Name).IsRequired().HasMaxLength(100);
        builder.Property(r => r.Description).HasMaxLength(255);
        builder.Property(r => r.Capacity).IsRequired();
        builder.Property(r => r.Floor).IsRequired();

        builder.HasIndex(r => r.Name).IsUnique(); // Optional uniqueness
        builder.HasIndex(r => r.Floor);

    }
}
