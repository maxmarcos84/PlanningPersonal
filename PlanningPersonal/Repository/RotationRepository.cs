using Microsoft.EntityFrameworkCore;
using PlanningPersonal.Data;
using PlanningPersonal.Interfaces;
using PlanningPersonal.Models;

namespace PlanningPersonal.Repository
{
    public class RotationRepository : IRotationRepository
    {
        private readonly ApplicationDbContext _context;

        public RotationRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public bool Add(Rotation rotation)
        {
            _context.Add(rotation);
            return Save();
        }

        public bool Delete(Rotation rotation)
        {
            _context.Remove(rotation);
            return Save();
        }

        public async Task<IEnumerable<Rotation>> GetByDate(DateTime from, DateTime to)
        {
            return await _context.Rotations.Where(r => r.DateFrom >= from && r.DateTo <= to).ToListAsync();
        }

        public async Task<IEnumerable<Rotation>> GetByDateAndEmployee(int idEmployee, DateTime from, DateTime to)
        {
            return await _context.Rotations.Where(r => r.DateFrom >= from && r.DateTo <= to && r.Employee.Id == idEmployee).ToListAsync();
        }

        public async Task<IEnumerable<Rotation>> GetByEmployeeAsync(int idEmployee)
        {
            return await _context.Rotations.Where(r => r.Employee.Id == idEmployee).ToListAsync();
        }

        public async Task<Rotation?> GetByIdAsync(int id)
        {
            return await _context.Rotations.FirstOrDefaultAsync(r => r.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }

        public bool Update(Rotation rotation)
        {
            _context.Update(rotation);
            return Save();
        }
    }
}
