using GenericCalendar.Application.Bookings.BookItem;
using GenericCalendar.Domain.Messaging;

namespace GenericCalendar.Application.Bookings.GetBookingsForRange;

public class GetBookingsForRangeQuery : IRequest<List<BookingDto>>
{
    public DateTime From { get; set; }
    public DateTime To { get; set; }
}
