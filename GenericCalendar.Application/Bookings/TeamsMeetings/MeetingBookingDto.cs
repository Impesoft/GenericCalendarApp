using GenericCalendar.Application.Bookings.BookItem;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCalendar.Application.Bookings.TeamsMeetings;
public class MeetingBookingDto : BookingDto
{
    public string Organizer { get; set; } = default!;
    public List<string> Participants { get; set; } = new();
}