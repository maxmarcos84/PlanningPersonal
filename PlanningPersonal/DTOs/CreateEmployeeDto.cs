using PlanningPersonal.Models;
using System.ComponentModel.DataAnnotations;

namespace PlanningPersonal.DTOs
{
    public class CreateEmployeeDto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]       
        public string Dni { get; set; }
        [Required]
        public string EmployeeNumber { get; set; }
        
        [Required]
        public int CompanyId { get; set; }
        
        public int? DepartmentId { get; set; }
        
        public int? WorkingSiteId { get; set; }

    }
}
