using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCalendar.Domain.Entities;
public class EquipmentEntity : BookableItemEntity
{
    public string SerialNumber { get; set; } = string.Empty;
    public string EquipmentType { get; set; } = string.Empty;
    public bool RequiresTraining { get; set; }
}
