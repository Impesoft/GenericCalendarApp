using GenericCalendar.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GenericCalendar.Infrastructure.Persistence.Configuration;

public class InterviewSlotEntityConfiguration : IEntityTypeConfiguration<InterviewSlotEntity>
{
    public void Configure(EntityTypeBuilder<InterviewSlotEntity> builder)
    {
        builder.ToTable("InterviewSlots");

        builder.Property(i => i.Interviewer).IsRequired().HasMaxLength(100);
        builder.Property(i => i.CandidateEmail).IsRequired().HasMaxLength(100);

        builder.HasIndex(i => i.Interviewer);
        builder.HasIndex(i => i.CandidateEmail);
    }
}
