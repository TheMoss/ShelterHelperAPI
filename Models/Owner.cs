using System.ComponentModel.DataAnnotations;

namespace ShelterHelperAPI.Models
{
    public class Owner
    {
        [Key]
        public int? OwnerId { get; set; }
        public string OwnerName { get; set; }
        public string Address { get; set; }
        public string? Email { get; set; }
    }
}