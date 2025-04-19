using GenericCalendar.Application.Bookings.BookItem;
using System;

namespace GenericCalendar.Application.Bookings.FlightSeatBooking;
public class FlightSeatBookingDto : BaseSeatBookingDto
{
    public string FlightNumber { get; set; } = string.Empty;
    public string SeatClass { get; set; } = string.Empty;
}
