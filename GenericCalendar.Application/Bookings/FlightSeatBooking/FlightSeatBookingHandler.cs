using GenericCalendar.Application.Abstractions;
using GenericCalendar.Application.Bookings.BookItem;
using GenericCalendar.Domain.Entities;
using GenericCalendar.Domain.Enums;
using GenericCalendar.Domain.Messaging;

namespace GenericCalendar.Application.Bookings.FlightSeatBooking;

public class FlightSeatBookingHandler : IRequestHandler<FlightSeatBookingRequest, BookingResult>
{
    private readonly IBookingWriter _writer;

    public FlightSeatBookingHandler(IBookingWriter writer)
    {
        _writer = writer;
    }

    public async Task<BookingResult> HandleAsync(FlightSeatBookingRequest request)
    {
        var available = await _writer.IsAvailableAsync(request.FlightSeatId, request.Start, request.End);
        if (!available)
            return BookingResult.Failed("This flight seat is already booked in the given time range.");

        var booking = new BookingEntity
        {
            Id = Guid.NewGuid(),
            BookableItemId = request.FlightSeatId,
            Start = request.Start,
            End = request.End,
            Title = request.Title,
            BookedBy = request.UserId,
            Type = BookingType.FlightSeat
        };

        var id = await _writer.SaveBookingAsync(booking);
        return BookingResult.Succeeded(id);
    }
}
