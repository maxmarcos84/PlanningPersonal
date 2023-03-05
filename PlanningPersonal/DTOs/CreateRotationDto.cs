using PlanningPersonal.Models.Enum;
using PlanningPersonal.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PlanningPersonal.DTOs
{
    public class CreateRotationDto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime DateFrom { get; set; }
        [Required]
        public DateTime DateTo { get; set; }
        public RotationType RotationType { get; set; }
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        
    }
}
