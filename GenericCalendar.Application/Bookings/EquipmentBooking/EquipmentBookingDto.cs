using GenericCalendar.Application.Bookings.BookItem;
using System;

namespace GenericCalendar.Application.Bookings.EquipmentBooking;
public class EquipmentBookingDto : BookingDto
{
    public string SerialNumber { get; set; } = string.Empty;
    public string EquipmentType { get; set; } = string.Empty;
    public bool RequiresTraining { get; set; }
}