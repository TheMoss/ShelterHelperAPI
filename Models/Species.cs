using Microsoft.EntityFrameworkCore;
using ShelterHelperAPI.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ShelterHelperAPI.Models
{

	public class Species
	{
		[Key]
		public int? SpeciesId { get; set; }		
		public string SpeciesName { get; set; }
		public int DietId { get; set; }
		
		public virtual Diet? Diet { get; set; }
		public int BeddingId { get; set; }
		
		public virtual Bedding? Bedding { get; set; }
		public int ToyId { get; set; }
		
		public virtual Toy? Toy { get; set; }
		public int AccessoryId { get; set; }
		
		public virtual Accessory? Accessory { get; set; }
	}



	public class Diet
	{
		[Key]
		public int? DietId { get; set; }        
        public string DietName { get; set; }
        public int Quantity_kg { get; set; }
	}

	public class Bedding
	{
		[Key]
		public int? BeddingId { get; set; }
        public string BeddingName { get; set; }
        public int Quantity_kg { get; set; }
	}

	public class Toy
	{
		[Key]
		public int? ToyId { get; set; }
        public string ToyName { get; set; }
        public int Quantity { get; set; }
	}

	public class Accessory
	{
		[Key]
		public int? AccessoryId { get; set; }
        public string AccessoryName { get; set; }
        public int Quantity { get; set; }		
	}
}

