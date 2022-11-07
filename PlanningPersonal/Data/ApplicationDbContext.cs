using Microsoft.EntityFrameworkCore;
using PlanningPersonal.Models;

namespace PlanningPersonal.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Rotation> Rotations { get; set; }
        public DbSet<WorkingSite> WorkingSites { get; set; }

    }
}
