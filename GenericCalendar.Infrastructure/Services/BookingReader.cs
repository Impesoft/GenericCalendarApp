using GenericCalendar.Application.Abstractions;
using GenericCalendar.Application.Bookings.GetBookingsForRange;
using GenericCalendar.Domain.Entities;
using GenericCalendar.Domain.Enums;
using GenericCalendar.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GenericCalendar.Infrastructure.Services;

public class BookingReader : IBookingReader
{
    private readonly GenericCalendarDbContext _db;

    public BookingReader(GenericCalendarDbContext db)
    {
        _db = db;
    }

    public async Task<List<BookingDto>> GetBookingsInRangeAsync(DateTime from, DateTime to)
    {
        var bookings = await _db.Bookings
            .Include(b => b.Item)
            .Where(b => b.Start <= to && b.End >= from)
            .ToListAsync();

        var result = bookings.Select(b => new BookingDto
        {
            Id = b.Id,
            Title = b.Title,
            Start = b.Start,
            End = b.End,
            Type = b.Type.ToString(),
            Color = GetColor(b.Type),
            Organizer = b.Item is TeamMeetingEntity tm ? tm.Organizer : null,
            Participants = b.Item is TeamMeetingEntity team ? team.Participants : null
        }).ToList();
        return result;
    }

    private static string GetColor(BookingType type) => type switch
    {
        BookingType.Room => "#0078D4",
        BookingType.Seat => "#107C10",
        BookingType.TeamsMeeting => "#D83B01",
        BookingType.Appointment => "#5C2D91",
        _ => "#8A8886"
    };
}
