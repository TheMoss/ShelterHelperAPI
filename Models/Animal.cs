using System.ComponentModel.DataAnnotations;

namespace ShelterHelperAPI.Models
{
	public class Animal
	{		
		public int? Id { get; set; }
		public int SpeciesId { get; set; }
		public virtual Species? Species { get; set; }
		public string Name { get; set; }
		public string Sex { get; set; }
		public int Weight { get; set; }			
		public DateOnly AdmissionDay { get; set; }
		public DateOnly? AdoptionDay { get; set; }
		public string Health { get; set; }
		public int EmployeeId { get; set; }		
	}
}
