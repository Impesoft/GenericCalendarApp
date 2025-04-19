using GenericCalendar.Application.Bookings.BookItem;

namespace GenericCalendar.Application.Bookings.InterviewSlotBooking;
public class InterviewSlotBookingDto : BookingDto
{
    public string Interviewer { get; set; } = string.Empty;
    public string CandidateEmail { get; set; } = string.Empty;
}
