using GenericCalendar.Application.Abstractions;
using GenericCalendar.Application.Bookings.BookItem;
using GenericCalendar.Application.Bookings.RoomBookings;
using GenericCalendar.Application.Bookings.SeatBookings;
using GenericCalendar.Application.Bookings.TeamsMeetings;
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
            Type = b.Type,
            Color = GetColor(b.Type),
        }).ToList();
        return result;
    }
    public async Task<BookingDto> GetBookingByIdAsync(Guid id)
    {
        var booking = await _db.Bookings
            .Include(b => b.Item)
            .FirstOrDefaultAsync(b => b.Id == id);
        if (booking == null)
        {
            return null!;
            //throw new Exception($"Booking with ID {id} not found.");
        }
        return booking.Item switch
        {
            RoomEntity room => new RoomBookingDto
            {
                Id = booking.Id,
                Title = booking.Title,
                Start = booking.Start,
                End = booking.End,
                Type = booking.Type,
                Color = GetColor(booking.Type),
                Floor = room.Floor,
                Capacity = room.Capacity
            },
            SeatEntity seat => new SeatBookingDto
            {
                Id = booking.Id,
                Title = booking.Title,
                Start = booking.Start,
                End = booking.End,
                Type = booking.Type,
                Color = GetColor(booking.Type),
                Row = seat.Row,
                Number = seat.Number
            },
            TeamMeetingEntity meeting => new MeetingBookingDto
            {
                Id = booking.Id,
                Title = booking.Title,
                Start = booking.Start,
                End = booking.End,
                Type = booking.Type,
                Color = GetColor(booking.Type),
                Organizer = meeting.Organizer,
                Participants = meeting.Participants
            },
            _ => new BookingDto
            {
                Id = booking.Id,
                Title = booking.Title,
                Start = booking.Start,
                End = booking.End,
                Type = booking.Type,
                Color = GetColor(booking.Type)
            }
        };
    }

    private static string GetColor(BookingType type) => type switch
    {
        BookingType.Room => "#FF0000", // Bright Red
        BookingType.Seat => "#00FF00", // Bright Green
        BookingType.TeamsMeeting => "#0000FF", // Bright Blue
        BookingType.Equipment => "#FFFF00", // Bright Yellow
        BookingType.FlightSeat => "#FF00FF", // Bright Magenta
        BookingType.InterviewSlot => "#00FFFF", // Bright Cyan
        BookingType.ParkingSpot => "#FFA500", // Bright Orange
        BookingType.SportsField => "#800080", // Bright Purple

        _ => "#8A8886"
    };
}
