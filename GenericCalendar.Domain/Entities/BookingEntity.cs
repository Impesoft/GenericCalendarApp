using GenericCalendar.Domain.Enums;

namespace GenericCalendar.Domain.Entities;

public class BookingEntity
{
    public Guid Id { get; set; }

    public Guid BookableItemId { get; set; }
    public BookableItemEntity Item { get; set; } = default!;

    public DateTime Start { get; set; }
    public DateTime End { get; set; }

    public string Title { get; set; } = string.Empty;
    public string BookedBy { get; set; } = string.Empty;

    public BookingType Type { get; set; }
}
