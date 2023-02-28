using System.ComponentModel.DataAnnotations;

namespace PlanningPersonal.DTOs
{
    public class WorkingSiteDto
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool? IsActive { get; set; } = true;
    }
}
