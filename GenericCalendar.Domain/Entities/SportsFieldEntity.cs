using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCalendar.Domain.Entities;
public class SportsFieldEntity : BookableItemEntity
{
    public string FieldType { get; set; } = "Soccer";
    public bool HasLighting { get; set; }
}
