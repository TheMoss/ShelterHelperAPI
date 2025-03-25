using System.ComponentModel.DataAnnotations;

namespace ShelterHelperAPI.Models;

public class EmployeesAssignments
{
    [Key]
    public int? Id { get; set; }
    
    public int EmployeeId { get; set; }
    public int AssignmentId { get; set; }

    public virtual Employee? Employee { get; set; }
    public virtual Assignment? Assignment { get; set; }
}