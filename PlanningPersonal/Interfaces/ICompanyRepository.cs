using PlanningPersonal.Models;
using System.Diagnostics;

namespace PlanningPersonal.Interfaces
{
    public interface ICompanyRepository
    {
        Task<Company?> GetByIdAsync(int id);
        Task<IEnumerable<Company?>> GetByNameAsync(string name);
        Task<IEnumerable<Company>> GetAllAsync();
        bool Add(Company company);
        bool Update(Company company);
        bool Delete(Company company);
        bool Save();
    }
}
