namespace GenericCalendar.Domain.Entities;

public class BaseSeatEntity : BookableItemEntity
{
    public string Row { get; set; } = string.Empty;
    public int Number { get; set; }
}

