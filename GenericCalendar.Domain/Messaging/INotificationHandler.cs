namespace GenericCalendar.Domain.Messaging;

public interface INotificationHandler<TNotification>
    where TNotification : INotification
{
    Task HandleAsync(TNotification notification);
}
