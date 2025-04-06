namespace GenericCalendar.Application.Bookings.GetBookingsForRange;

public class BookingDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public string Type { get; set; } = string.Empty;
    public string Color { get; set; } = string.Empty;

    public string? Organizer { get; set; }
    public List<string>? Participants { get; set; }
}
