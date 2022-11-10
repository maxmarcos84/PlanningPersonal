using PlanningPersonal.Models;

namespace PlanningPersonal.Interfaces
{
    public interface IWorkingSiteRepository
    {
        Task<WorkingSite> GetByIdAsync(int id);
        Task<WorkingSite> GetByNameAsync(string name);
        Task<IEnumerable<WorkingSite>> GetAllAsync();
        bool Add(WorkingSite workingSite);
        bool Update(WorkingSite workingSite);
        bool Delete(WorkingSite workingSite);
        bool Save();
    }
}
