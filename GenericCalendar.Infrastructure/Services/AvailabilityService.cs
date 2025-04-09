using GenericCalendar.Domain.Entities;
using GenericCalendar.Domain.Interfaces;
using GenericCalendar.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GenericCalendar.Infrastructure.Services;

public class AvailabilityService : IAvailabilityService
{
    private readonly GenericCalendarDbContext _db;

    public AvailabilityService(GenericCalendarDbContext db)
    {
        _db = db;
    }

    public async Task<bool> IsAvailableAsync(Guid bookableItemId, DateTime start, DateTime end)
    {
        return !await _db.Bookings
            .Where(b => b.BookableItemId == bookableItemId &&
                        b.Start < end &&
                        b.End > start)
            .AnyAsync();
    }
    public async Task<List<BookingEntity>> GetConflictingBookingsAsync(Guid bookableItemId, DateTime start, DateTime end)
    {
        return await _db.Bookings
            .Where(b => b.BookableItemId == bookableItemId &&
                        b.Start < end &&
                        b.End > start)
            .ToListAsync();
    }
}
