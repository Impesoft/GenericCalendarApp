using GenericCalendar.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GenericCalendar.Infrastructure.Persistence.Configuration;

public class BookingEntityConfiguration : IEntityTypeConfiguration<BookingEntity>
{
    public void Configure(EntityTypeBuilder<BookingEntity> builder)
    {
        builder.ToTable("Bookings");

        builder.Property(b => b.Title).IsRequired().HasMaxLength(100);
        builder.Property(b => b.BookedBy).IsRequired().HasMaxLength(100);

        builder.HasOne(b => b.Item)
               .WithMany()
               .HasForeignKey(b => b.BookableItemId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(b => new { b.BookableItemId, b.Start, b.End });
        builder.Property(b => b.Title).IsRequired().HasMaxLength(100);
        builder.Property(b => b.BookedBy).IsRequired().HasMaxLength(100);


    }
}
