namespace GenericCalendar.Domain.Entities;

public class RoomEntity : BookableItemEntity
{
    public int Floor { get; set; }
    public int Capacity { get; set; }
}
