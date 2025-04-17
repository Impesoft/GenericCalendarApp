using GenericCalendar.Application.Abstractions;
using GenericCalendar.Application.Bookings.BookItem;
using GenericCalendar.Application.Bookings.GetBookingById;
using GenericCalendar.Application.Shared;
using GenericCalendar.Domain.Interfaces;
using GenericCalendar.Domain.Messaging;
using GenericCalendar.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace GenericCalendar.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IDispatcher, Dispatcher>();
        services.AddScoped<IBookingWriter, BookingWriter>();
        services.AddScoped<IBookingReader, BookingReader>();
        services.AddScoped<IAvailabilityService, AvailabilityService>();
        services.AddScoped<IRequestHandler<GetBookingByIdQuery, BookingDto>, GetBookingByIdHandler>();

        // add other infra services here in the future

        return services;
    }
}
