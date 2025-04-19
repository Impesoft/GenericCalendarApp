using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCalendar.Domain.Entities;
public class ParkingSpotEntity : BookableItemEntity
{
    public int SpotNumber { get; set; }
    public string Level { get; set; } = string.Empty;
    public bool IsCovered { get; set; }
}
