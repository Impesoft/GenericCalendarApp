using GenericCalendar.Domain.Enums;
using GenericCalendar.Domain.Messaging;

namespace GenericCalendar.Application.Bookings.BookItem;

public class BookItemRequest : IRequest<BookingResult>
{
    public Guid ItemId { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public string Title { get; set; } = string.Empty;
    public string UserId { get; set; } = string.Empty;
    public BookingType Type { get; set; }
}
