using GenericCalendar.Application.Abstractions;
using GenericCalendar.Domain.Entities;
using GenericCalendar.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GenericCalendar.Infrastructure.Services;

public class BookingWriter : IBookingWriter
{
    private readonly GenericCalendarDbContext _db;

    public BookingWriter(GenericCalendarDbContext db)
    {
        _db = db;
    }

    public async Task<bool> IsAvailableAsync(Guid itemId, DateTime start, DateTime end)
    {
        return !await _db.Bookings
            .AnyAsync(b => b.BookableItemId == itemId &&
                           b.Start < end &&
                           b.End > start);
    }

    public async Task<Guid> SaveBookingAsync(BookingEntity booking)
    {
        _db.Bookings.Add(booking);
        await _db.SaveChangesAsync();
        return booking.Id;
    }
}
