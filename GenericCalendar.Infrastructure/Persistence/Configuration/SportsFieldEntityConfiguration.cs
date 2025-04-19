using GenericCalendar.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GenericCalendar.Infrastructure.Persistence.Configuration;

public class SportsFieldEntityConfiguration : IEntityTypeConfiguration<SportsFieldEntity>
{
    public void Configure(EntityTypeBuilder<SportsFieldEntity> builder)
    {
        builder.ToTable("SportsFields");

        builder.Property(f => f.FieldType).IsRequired().HasMaxLength(50);
        builder.Property(f => f.HasLighting).IsRequired();

        builder.HasIndex(f => f.FieldType);
    }
}
