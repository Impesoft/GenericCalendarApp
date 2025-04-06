using GenericCalendar.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GenericCalendar.Infrastructure.Persistence.Configuration;

public class TeamMeetingEntityConfiguration : IEntityTypeConfiguration<TeamMeetingEntity>
{
    public void Configure(EntityTypeBuilder<TeamMeetingEntity> builder)
    {
        builder.ToTable("TeamMeetings");

        builder.Property(m => m.Organizer).IsRequired().HasMaxLength(100);
        builder.Property(m => m.Participants)
               .HasConversion(
                   v => string.Join(';', v),
                   v => v.Split(';', StringSplitOptions.RemoveEmptyEntries).ToList()
               );

        builder.HasIndex(m => m.Organizer);

    }
}
