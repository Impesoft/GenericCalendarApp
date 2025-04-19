using GenericCalendar.Application.Abstractions;
using GenericCalendar.Application.Bookings.BookItem;
using GenericCalendar.Domain.Entities;
using GenericCalendar.Domain.Enums;
using GenericCalendar.Domain.Messaging;

namespace GenericCalendar.Application.Bookings.SeatBookings;

public class SeatBookingHandler : IRequestHandler<SeatBookingRequest, BookingResult>
{
    private readonly IBookingWriter _writer;

    public SeatBookingHandler(IBookingWriter writer)
    {
        _writer = writer;
    }

    public async Task<BookingResult> HandleAsync(SeatBookingRequest request)
    {
        var available = await _writer.IsAvailableAsync(request.SeatId, request.Start, request.End);
        if (!available)
            return BookingResult.Failed("This seat is already booked in the given time range.");

        var booking = new BookingEntity
        {
            Id = Guid.NewGuid(),
            BookableItemId = request.SeatId,
            Start = request.Start,
            End = request.End,
            Title = request.Title,
            BookedBy = request.UserId,
            Type = BookingType.Seat
        };

        var id = await _writer.SaveBookingAsync(booking);
        return BookingResult.Succeeded(id);
    }
}
