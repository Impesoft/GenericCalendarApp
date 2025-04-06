using GenericCalendar.Application.Abstractions;
using GenericCalendar.Domain.Entities;
using GenericCalendar.Domain.Messaging;

namespace GenericCalendar.Application.Bookings.BookItem;

public class BookItemHandler : IRequestHandler<BookItemRequest, BookingResult>
{
    private readonly IBookingWriter _writer;

    public BookItemHandler(IBookingWriter writer)
    {
        _writer = writer;
    }

    public async Task<BookingResult> HandleAsync(BookItemRequest request)
    {
        var available = await _writer.IsAvailableAsync(request.ItemId, request.Start, request.End);
        if (!available)
            return BookingResult.Failed("This item is already booked in the given time range.");

        var booking = new BookingEntity
        {
            Id = Guid.NewGuid(),
            BookableItemId = request.ItemId,
            Start = request.Start,
            End = request.End,
            Title = request.Title,
            BookedBy = request.UserId,
            Type = request.Type
        };

        var id = await _writer.SaveBookingAsync(booking);
        return BookingResult.Succeeded(id);
    }
}
