using GenericCalendar.Application.Abstractions;
using GenericCalendar.Application.Bookings.BookItem;
using GenericCalendar.Domain.Messaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCalendar.Application.Bookings.GetBookingById;
public class GetBookingByIdHandler : IRequestHandler<GetBookingByIdQuery, BookingDto>
{
    private readonly IBookingReader _reader;
    public GetBookingByIdHandler(IBookingReader reader)
    {
        _reader = reader;
    }
    public async Task<BookingDto> HandleAsync(GetBookingByIdQuery request)
    {
        var booking = await _reader.GetBookingByIdAsync(request.Id);
        return booking;
    }
}
