using GenericCalendar.Application.Bookings.BookItem;

namespace GenericCalendarApp.Services;

public interface IBookingApiClient
{
    Task<BookingDto?> GetBookingByIdAsync(Guid id);
    Task<List<BookingDto>> GetBookingsAsync(DateTime from, DateTime to);
    Task<bool> BookAsync(BookItemRequest request);
}
