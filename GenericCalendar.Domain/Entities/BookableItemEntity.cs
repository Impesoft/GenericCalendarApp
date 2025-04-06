using GenericCalendar.Domain.Contracts;

namespace GenericCalendar.Domain.Entities;

public abstract class BookableItemEntity : IBookableItem
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}
