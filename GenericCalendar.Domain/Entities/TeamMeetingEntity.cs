namespace GenericCalendar.Domain.Entities;

public class TeamMeetingEntity : BookableItemEntity
{
    public List<string> Participants { get; set; } = new();
    public string Organizer { get; set; } = string.Empty;
}
