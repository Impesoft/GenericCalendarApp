using GenericCalendar.Domain.Entities;

namespace GenericCalendar.Application.Abstractions;

public interface IBookingWriter
{
    Task<bool> IsAvailableAsync(Guid itemId, DateTime start, DateTime end);
    Task<Guid> SaveBookingAsync(BookingEntity booking);
}
