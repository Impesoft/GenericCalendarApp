using GenericCalendar.Application.Bookings.GetBookingsForRange;

namespace GenericCalendar.Application.Abstractions;

public interface IBookingReader
{
    Task<List<BookingDto>> GetBookingsInRangeAsync(DateTime from, DateTime to);
}
