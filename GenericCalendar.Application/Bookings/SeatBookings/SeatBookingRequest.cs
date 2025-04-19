using GenericCalendar.Application.Bookings.BookItem;
using GenericCalendar.Domain.Enums;
using GenericCalendar.Domain.Messaging;

namespace GenericCalendar.Application.Bookings.SeatBookings;

public class SeatBookingRequest : IRequest<BookingResult>
{
    public Guid SeatId { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public string Title { get; set; } = string.Empty;
    public string UserId { get; set; } = string.Empty;
}
