using System.ComponentModel.DataAnnotations;

namespace PlanningPersonal.Models
{
    public class WorkingSite
    {
        [Key]
        public int Id { get; set; } 
        [Required]
        public string Name { get; set; }
        public bool Active { get; set; } = true;
        public ICollection<Employee> Employees { get; set; }
    }
}
