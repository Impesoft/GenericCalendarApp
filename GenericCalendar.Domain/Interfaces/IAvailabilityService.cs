using GenericCalendar.Domain.Entities;

namespace GenericCalendar.Domain.Interfaces;

public interface IAvailabilityService
{
    Task<bool> IsAvailableAsync(Guid bookableItemId, DateTime start, DateTime end);
    Task<List<BookingEntity>> GetConflictingBookingsAsync(Guid bookableItemId, DateTime start, DateTime end);
}