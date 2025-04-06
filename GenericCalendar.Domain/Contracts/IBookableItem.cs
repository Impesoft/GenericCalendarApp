namespace GenericCalendar.Domain.Contracts;

public interface IBookableItem
{
    Guid Id { get; }
    string Name { get; }
    string Description { get; }
}
