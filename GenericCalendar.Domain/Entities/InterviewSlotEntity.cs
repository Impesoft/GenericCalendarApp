using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCalendar.Domain.Entities;
public class InterviewSlotEntity : BookableItemEntity
{
    public string Interviewer { get; set; } = string.Empty;
    public string CandidateEmail { get; set; } = string.Empty;
}
