namespace GenericCalendar.Application.Bookings.BookItem;

public record BookingResult(bool Success, string? ErrorMessage, Guid? BookingId)
{
    public static BookingResult Failed(string error) => new(false, error, null);
    public static BookingResult Succeeded(Guid id) => new(true, null, id);
}
