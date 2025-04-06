namespace GenericCalendar.Domain.Entities;

public class SeatEntity : BookableItemEntity
{
    public string Row { get; set; } = string.Empty;
    public int Number { get; set; }
}
