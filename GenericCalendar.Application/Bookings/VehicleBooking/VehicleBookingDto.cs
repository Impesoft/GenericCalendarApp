using GenericCalendar.Application.Bookings.BookItem;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCalendar.Application.Bookings.VehicleBooking;
public class VehicleBookingDto : BookingDto
{
    public string LicensePlate { get; set; } = string.Empty;
    public string Brand { get; set; } = string.Empty;
    public int Seats { get; set; }
}
