using System.ComponentModel.DataAnnotations;

namespace PlanningPersonal.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [Required]  
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool? IsActive { get; set; } = true;
        public ICollection<Employee>? Employees { get; set; }
    }
}
