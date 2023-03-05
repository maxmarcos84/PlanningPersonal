using Microsoft.AspNetCore.Mvc.Rendering;
using PlanningPersonal.Models;

namespace PlanningPersonal.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<Employee?> GetByIdAsync(int id);
        Task<IEnumerable<Employee>> GetAllAsync();
        public List<SelectListItem> GetCompaniesList();
        public List<SelectListItem> GetDepartmentList();
        public List<SelectListItem> GetWorkingSitesList();
        public Task<IEnumerable<Employee>> SearchByText(string text);
        bool Add(Employee employee);
        bool Update(Employee employee);
        bool Delete(Employee employee);
        bool Save();
    }
}
