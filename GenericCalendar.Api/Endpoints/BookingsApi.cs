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
