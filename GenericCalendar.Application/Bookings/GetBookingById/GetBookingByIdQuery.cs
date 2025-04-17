using GenericCalendar.Application.Bookings.BookItem;
using GenericCalendar.Domain.Messaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCalendar.Application.Bookings.GetBookingById;
public class GetBookingByIdQuery : IRequest<BookingDto>
{
    public Guid Id { get; set; }

    public GetBookingByIdQuery(Guid id)
    {
        Id = id;
    }
}
