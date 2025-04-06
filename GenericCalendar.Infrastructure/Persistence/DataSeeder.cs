using GenericCalendar.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GenericCalendar.Infrastructure.Persistence;

public static class DataSeeder
{
    public static void Seed(GenericCalendarDbContext db)
    {
        if (db.Rooms.Any()) return;

        db.Rooms.AddRange(
            new RoomEntity { Id = Guid.NewGuid(), Name = "Main Hall", Description = "Spacious event room", Floor = 1, Capacity = 50 },
            new RoomEntity { Id = Guid.NewGuid(), Name = "Meeting Room A", Description = "Small team meeting", Floor = 2, Capacity = 10 }
        );

        db.Seats.AddRange(
            new SeatEntity { Id = Guid.NewGuid(), Name = "Seat A1", Description = "Front row", Row = "A", Number = 1 },
            new SeatEntity { Id = Guid.NewGuid(), Name = "Seat A2", Description = "Front row", Row = "A", Number = 2 }
        );

        db.TeamMeetings.Add(
            new TeamMeetingEntity
            {
                Id = Guid.NewGuid(),
                Name = "Weekly Sync",
                Description = "Recurring standup",
                Organizer = "alice@example.com",
                Participants = new() { "bob@example.com", "carol@example.com" }
            }
        );

        db.SaveChanges();
    }
}
