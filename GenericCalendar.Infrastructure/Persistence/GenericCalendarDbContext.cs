using GenericCalendar.Domain.Entities;
using GenericCalendar.Domain.Enums;
using GenericCalendar.Infrastructure.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;

namespace GenericCalendar.Infrastructure.Persistence;

public class GenericCalendarDbContext : DbContext
{
    public GenericCalendarDbContext(DbContextOptions<GenericCalendarDbContext> options)
        : base(options) { }

    public DbSet<BookingEntity> Bookings => Set<BookingEntity>();
    public DbSet<BookableItemEntity> BookableItems => Set<BookableItemEntity>();
    public DbSet<RoomEntity> Rooms => Set<RoomEntity>();
    public DbSet<SeatEntity> Seats => Set<SeatEntity>();
    public DbSet<TeamMeetingEntity> TeamMeetings => Set<TeamMeetingEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new RoomEntityConfiguration());
        modelBuilder.ApplyConfiguration(new SeatEntityConfiguration());
        modelBuilder.ApplyConfiguration(new TeamMeetingEntityConfiguration());
        modelBuilder.ApplyConfiguration(new BookingEntityConfiguration());
        base.OnModelCreating(modelBuilder);

        var mainHallId = Guid.Parse("ed52fdcf-87fa-4f6d-ae09-b15419fecd72");
        var meetingRoomAId = Guid.Parse("c4f7a089-5bc6-43d0-b95d-739c2489ac4d");
        var seatA1Id = Guid.Parse("3a91263e-61a2-4b78-927f-01a8f331ec11");
        var weeklySyncId = Guid.Parse("6e282e43-8825-42e6-a3a1-1f1eb9f7a0c3");

        modelBuilder.Entity<RoomEntity>().HasData(
            new RoomEntity
            {
                Id = mainHallId,
                Name = "Main Hall",
                Description = "Large presentation room",
                Floor = 1,
                Capacity = 100
            },
            new RoomEntity
            {
                Id = meetingRoomAId,
                Name = "Meeting Room A",
                Description = "Medium room",
                Floor = 2,
                Capacity = 12
            }
        );

        modelBuilder.Entity<SeatEntity>().HasData(
            new SeatEntity
            {
                Id = seatA1Id,
                Name = "Seat A1",
                Description = "Front row left",
                Row = "A",
                Number = 1
            }
        );

        modelBuilder.Entity<TeamMeetingEntity>().HasData(
            new TeamMeetingEntity
            {
                Id = weeklySyncId,
                Name = "Weekly Sync",
                Description = "Weekly check-in",
                Organizer = "lead@example.com",
                Participants = ["alice@example.com", "bob@example.com"]
            }
        );

        modelBuilder.Entity<BookingEntity>().HasData(
            new BookingEntity
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000101"),
                BookableItemId = mainHallId,
                Start = new DateTime(2025, 4, 7, 9, 0, 0),
                End = new DateTime(2025, 4, 7, 11, 0, 0),
                Title = "Project Kickoff",
                BookedBy = "alice@example.com",
                Type = BookingType.Room
            },
            new BookingEntity
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000102"),
                BookableItemId = seatA1Id,
                Start = new DateTime(2025, 4, 8, 10, 0, 0),
                End = new DateTime(2025, 4, 8, 10, 30, 0),
                Title = "Seat A1 Reserved",
                BookedBy = "carol@example.com",
                Type = BookingType.Seat
            }
        );
    }
}
