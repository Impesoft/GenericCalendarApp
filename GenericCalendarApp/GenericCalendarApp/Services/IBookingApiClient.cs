using GenericCalendar.Application.Bookings.BookItem;
using GenericCalendar.Application.Bookings.GetBookingsForRange;

namespace GenericCalendarApp.Services;

public interface IBookingApiClient
{
    Task<List<BookingDto>> GetBookingsAsync(DateTime from, DateTime to);
    Task<bool> BookAsync(BookItemRequest request);
}
