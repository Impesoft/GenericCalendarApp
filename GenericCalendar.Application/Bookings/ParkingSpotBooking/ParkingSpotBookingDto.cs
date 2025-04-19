using GenericCalendar.Application.Bookings.BookItem;

namespace GenericCalendar.Application.Bookings.ParkingSpotBooking;
public class ParkingSpotBookingDto : BookingDto
{
    public int SpotNumber { get; set; }
    public string Level { get; set; } = string.Empty;
    public bool IsCovered { get; set; }
}
