using GenericCalendar.Application.Bookings.BookItem;

namespace GenericCalendar.Application.Abstractions;

public interface IBookingReader
{
    Task<List<BookingDto>> GetBookingsInRangeAsync(DateTime from, DateTime to);
    Task<BookingDto> GetBookingByIdAsync(Guid id);
}
