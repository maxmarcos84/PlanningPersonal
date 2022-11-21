using Microsoft.EntityFrameworkCore;
using PlanningPersonal.Data;
using PlanningPersonal.Interfaces;
using PlanningPersonal.Models;

namespace PlanningPersonal.Repository
{
    public class WorkingSiteRepository : IWorkingSiteRepository
    {
        private readonly ApplicationDbContext _context;

        public WorkingSiteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(WorkingSite workingSite)
        {
            _context.Add(workingSite);
            return Save();
        }

        public bool Delete(WorkingSite workingSite)
        {
            workingSite.IsActive = false;
            return Update(workingSite);
        }

        public async Task<IEnumerable<WorkingSite>> GetAllAsync()
        {
            return await _context.WorkingSites.Where(w => w.IsActive == true).ToListAsync();
        }

        public async Task<WorkingSite?> GetByIdAsync(int id)
        {
            return await _context.WorkingSites.FirstOrDefaultAsync(w => w.Id == id && w.IsActive == true);
        }

        public async Task<IEnumerable<WorkingSite?>> GetByNameAsync(string name)
        {
            return await _context.WorkingSites.Where(w => w.Name.Contains(name)).ToListAsync();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }

        public bool Update(WorkingSite workingSite)
        {
            _context.Update(workingSite);
            return Save();
        }
    }
}
