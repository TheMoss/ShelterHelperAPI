namespace ShelterHelperAPI.Models;

public class Assignment
{
    public int? AssignmentId { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public int Priority { get; set; }
    public int CreatorId { get; set; }
    public DateOnly? CreationDate { get; set; }
    public bool? IsCompleted { get; set; } = false;
    public bool? IsInProgress { get; set; } = false;
}