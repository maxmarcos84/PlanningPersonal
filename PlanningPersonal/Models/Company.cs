using System.ComponentModel.DataAnnotations;

namespace PlanningPersonal.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }        
        [Required]
        public string Name { get; set; } 
        public string? Description { get; set; }
        public string? Address { get; set; }


    }
}
