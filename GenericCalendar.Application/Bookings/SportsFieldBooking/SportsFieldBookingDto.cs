using GenericCalendar.Application.Bookings.BookItem;

namespace GenericCalendar.Application.Bookings.SportsFieldBooking;
public class SportsFieldBookingDto : BookingDto
{
    public string FieldType { get; set; } = "Soccer";
    public bool HasLighting { get; set; }
}
