using GenericCalendar.Application.Bookings.GetBookingsForRange;
using GenericCalendar.Application.Bookings.BookItem;
using GenericCalendar.Application.Shared;
using Microsoft.AspNetCore.Mvc;

namespace GenericCalendar.Api.Endpoints;

public static class BookingsApi
{
    public static void MapBookingsApi(this IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup("/api/bookings");

        group.MapGet("/", async (
            [FromQuery] DateTime from,
            [FromQuery] DateTime to,
            IDispatcher dispatcher) =>
        {
            // if from = to set the hours for from to end of the day
            if (from == to)
            {
                if (from.Hour == 0 && from.Minute == 0 && from.Second == 0)
                {
                    from = from.Date.AddHours(0).AddMinutes(0).AddSeconds(0);
                    to = to.AddHours(23).AddMinutes(59).AddSeconds(59);
                }
            }
            var query = new GetBookingsForRangeQuery { From = from, To = to };
            var result = await dispatcher.SendAsync(query);
            return Results.Ok(result);
        });

        group.MapPost("/", async (
            [FromBody] BookItemRequest request,
            IDispatcher dispatcher) =>
        {
            var result = await dispatcher.SendAsync(request);
            return result.Success ?
            Results.Created($"/api/bookings/{result.BookingId}", result) :
            Results.BadRequest(result.ErrorMessage);
        });
    }
}
