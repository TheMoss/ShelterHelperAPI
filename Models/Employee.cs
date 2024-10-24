using System.ComponentModel.DataAnnotations;

namespace ShelterHelperAPI.Models
{ 
	public class Employee
	{
		[Key]
		public int EmployeeId { get; set; }		
		public int EmployeePersonalId{ get; set; }
		public string EmployeeName { get; set; }
	}
}