using System.Reflection;
using GenericCalendar.Domain.Messaging;
using Microsoft.Extensions.DependencyInjection;

namespace GenericCalendar.Application.Shared;

public class Dispatcher : IDispatcher
{
    private readonly IServiceProvider _services;

    public Dispatcher(IServiceProvider services)
    {
        _services = services;
    }

    public async Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request)
    {
        var handlerType = typeof(IRequestHandler<,>).MakeGenericType(request.GetType(), typeof(TResponse));
        dynamic handler = _services.GetRequiredService(handlerType);
        return await handler.HandleAsync((dynamic)request);
    }

    public async Task PublishAsync<TNotification>(TNotification notification) where TNotification : INotification
    {
        var handlerType = typeof(INotificationHandler<>).MakeGenericType(notification.GetType());
        var handlers = _services.GetServices(handlerType);

        foreach (dynamic handler in handlers)
        {
            await handler.HandleAsync((dynamic)notification);
        }
    }
}
