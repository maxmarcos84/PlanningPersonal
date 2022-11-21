using Microsoft.EntityFrameworkCore;
using PlanningPersonal.Data;
using PlanningPersonal.Interfaces;
using PlanningPersonal.Models;

namespace PlanningPersonal.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _context;

        public DepartmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(Department department)
        {
            _context.Add(department);
            return Save();
        }

        public bool Delete(Department department)
        {
            department.IsActive = false;
            return Update(department);
        }

        public async Task<IEnumerable<Department>> GetAllAsync()
        {
            return await _context.Departments.Where(d => d.IsActive == true).ToListAsync();
        }

        public async Task<Department?> GetByIdAsync(int id)
        {
            return await _context.Departments.FirstOrDefaultAsync(x => x.Id == id && x.IsActive == true);
        }

        public async Task<IEnumerable<Department>> GetByNameAsync(string name)
        {
            return await _context.Departments.Where(d => d.Name.Contains(name)).ToListAsync();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }

        public bool Update(Department department)
        {
            _context.Update(department);
            return Save();
        }
    }
}
