using PlanningPersonal.Models;

namespace PlanningPersonal.Interfaces
{
    public interface IDepartmentRepository
    {
        Task<Department?> GetByIdAsync(int id);
        Task<IEnumerable<Department?>> GetByNameAsync(string name);
        Task<IEnumerable<Department>> GetAllAsync();
        bool Add(Department department);
        bool Update(Department department);
        bool Delete(Department department);
        bool Save();
    }
}
