using GenericCalendar.Application.Abstractions;
using GenericCalendar.Application.Bookings.BookItem;
using GenericCalendar.Domain.Entities;
using GenericCalendar.Domain.Enums;
using GenericCalendar.Domain.Messaging;

namespace GenericCalendar.Application.Bookings.RoomBookings;

public class RoomBookingHandler : IRequestHandler<RoomBookingRequest, BookingResult>
{
    private readonly IBookingWriter _writer;

    public RoomBookingHandler(IBookingWriter writer)
    {
        _writer = writer;
    }

    public async Task<BookingResult> HandleAsync(RoomBookingRequest request)
    {
        var available = await _writer.IsAvailableAsync(request.RoomId, request.Start, request.End);
        if (!available)
            return BookingResult.Failed("This room is already booked in the given time range.");

        var booking = new BookingEntity
        {
            Id = Guid.NewGuid(),
            BookableItemId = request.RoomId,
            Start = request.Start,
            End = request.End,
            Title = request.Title,
            BookedBy = request.UserId,
            Type = BookingType.Room
        };

        var id = await _writer.SaveBookingAsync(booking);
        return BookingResult.Succeeded(id);
    }
}
