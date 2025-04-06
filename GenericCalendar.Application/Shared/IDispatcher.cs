using GenericCalendar.Domain.Messaging;

namespace GenericCalendar.Application.Shared;

public interface IDispatcher
{
    Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request);
    Task PublishAsync<TNotification>(TNotification notification) where TNotification : INotification;
}
