using GenericCalendar.Domain.Enums;

namespace GenericCalendar.Application.Bookings.BookItem;

public class BookingDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public BookingType Type { get; set; } = BookingType.None;
    public string Color { get; set; } = string.Empty;
}
