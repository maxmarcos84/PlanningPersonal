using PlanningPersonal.Models;

namespace PlanningPersonal.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<Employee> GetByIdAsync(int id);
        Task<IEnumerable<Employee>> GetAllAsync();
        bool Add(Employee employee);
        bool Update(Employee employee);
        bool Delete(Employee employee);
        bool Save();
    }
}
