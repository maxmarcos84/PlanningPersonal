using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanningPersonal.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Dni { get; set; }
        public string EmployeeNumber { get; set; }
        public bool IsActive { get; set; } = true;
        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        [ForeignKey("Department")]
        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }
        [ForeignKey("WorkingSite")]
        public int? WorkingSiteId { get; set; }
        public WorkingSite? WorkingSite { get; set; }
        public ICollection<Rotation> Rotations { get; set; }
    }
}
