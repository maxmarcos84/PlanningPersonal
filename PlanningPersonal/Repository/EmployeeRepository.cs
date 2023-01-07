using Microsoft.EntityFrameworkCore;
using PlanningPersonal.Data;
using PlanningPersonal.Interfaces;
using PlanningPersonal.Models;

namespace PlanningPersonal.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(Employee employee)
        {
            _context.Employees.Add(employee);
            return Save();
        }

        public bool Delete(Employee employee)
        {
            employee.IsActive = false;
            return Update(employee);
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _context.Employees.Where(e => e.IsActive == true).ToListAsync();
        }

        public async Task<Employee?> GetByIdAsync(int id)
        {
            return await _context.Employees.FirstOrDefaultAsync(e => e.Id == id && e.IsActive == true);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }

        public bool Update(Employee employee)
        {
            _context.Employees.Update(employee);
            return Save();
        }
    }
}
