using PlanningPersonal.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PlanningPersonal.Data;

namespace PlanningPersonal.DTOs
{
    public class EmployeeDto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [RegularExpression("([0-9]+$)")]
        public string Dni { get; set; }
        [Required]        
        public string EmployeeNumber { get; set; }
        public bool? IsActive { get; set; } = true;
        [Required]
        public Company Company { get; set; }      
        public Department? Department { get; set; }        
        public WorkingSite? WorkingSite { get; set; }            
    }
}
