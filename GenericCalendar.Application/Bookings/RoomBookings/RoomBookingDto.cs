using GenericCalendar.Application.Bookings.BookItem;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCalendar.Application.Bookings.RoomBookings;
public class RoomBookingDto : BookingDto
{
    public int Floor { get; set; }
    public int Capacity { get; set; }
}