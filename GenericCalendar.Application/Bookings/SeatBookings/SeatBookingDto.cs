using GenericCalendar.Application.Bookings.BookItem;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCalendar.Application.Bookings.SeatBookings;
public class SeatBookingDto : BookingDto
{
    public string Row { get; set; } = default!;
    public int Number { get; set; }
}
