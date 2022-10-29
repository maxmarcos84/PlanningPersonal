using System.ComponentModel.DataAnnotations;

namespace PlanningPersonal.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [Required]  
        public string Name { get; set; }
        public bool Activo { get; set; } = true;
    }
}
