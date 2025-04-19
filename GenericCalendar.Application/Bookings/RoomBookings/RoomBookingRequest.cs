using GenericCalendar.Application.Bookings.BookItem;
using GenericCalendar.Domain.Enums;
using GenericCalendar.Domain.Messaging;

namespace GenericCalendar.Application.Bookings.RoomBookings;

public class RoomBookingRequest : IRequest<BookingResult>
{
    public Guid RoomId { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public string Title { get; set; } = string.Empty;
    public string UserId { get; set; } = string.Empty;
}
