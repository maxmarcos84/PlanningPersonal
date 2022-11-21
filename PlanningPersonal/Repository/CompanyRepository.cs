using Microsoft.EntityFrameworkCore;
using PlanningPersonal.Data;
using PlanningPersonal.Interfaces;
using PlanningPersonal.Models;

namespace PlanningPersonal.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ApplicationDbContext _context;

        public CompanyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(Company company)
        {
            _context.Add(company);
            return Save();
        }

        public bool Delete(Company company)
        {
            company.IsActive = false;
            return true;
        }

        public async Task<IEnumerable<Company>> GetAllAsync()
        {
            return await _context.Companies.Where(c => c.IsActive == true).ToListAsync();
        }

        public async Task<Company?> GetByIdAsync(int id)
        {
            return await _context.Companies.FirstOrDefaultAsync(i => i.Id == id && i.IsActive == true);
        }

        public async Task<IEnumerable<Company?>> GetByNameAsync(string name)
        {
            return await _context.Companies.Where(c => c.Name.Contains(name)).ToListAsync();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }

        public bool Update(Company company)
        {
            _context.Update(company);
            return Save();
        }
    }
}
