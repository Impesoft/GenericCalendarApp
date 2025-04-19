using GenericCalendar.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GenericCalendar.Infrastructure.Persistence.Configuration;

public class EquipmentEntityConfiguration : IEntityTypeConfiguration<EquipmentEntity>
{
    public void Configure(EntityTypeBuilder<EquipmentEntity> builder)
    {
        builder.ToTable("Equipment");

        builder.Property(e => e.SerialNumber).IsRequired().HasMaxLength(100);
        builder.Property(e => e.EquipmentType).IsRequired().HasMaxLength(50);
        builder.Property(e => e.RequiresTraining).IsRequired();

        builder.HasIndex(e => e.SerialNumber).IsUnique();
    }
}
