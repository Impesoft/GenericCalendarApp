using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCalendar.Domain.Entities;
public class FlightSeatEntity :BaseSeatEntity
{
    public string FlightNumber { get; set; } = string.Empty;
    public string SeatClass { get; set; } = string.Empty;

}
