using GenericCalendar.Application.Abstractions;
using GenericCalendar.Domain.Messaging;

namespace GenericCalendar.Application.Bookings.GetBookingsForRange;

public class GetBookingsForRangeHandler : IRequestHandler<GetBookingsForRangeQuery, List<BookingDto>>
{
    private readonly IBookingReader _reader;

    public GetBookingsForRangeHandler(IBookingReader reader)
    {
        _reader = reader;
    }

    public async Task<List<BookingDto>> HandleAsync(GetBookingsForRangeQuery request)
    {
        return await _reader.GetBookingsInRangeAsync(request.From, request.To);
    }
}
