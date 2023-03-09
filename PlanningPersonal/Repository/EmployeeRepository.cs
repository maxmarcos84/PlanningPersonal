using Microsoft.AspNetCore.Mvc.Rendering;
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
            /*if (employee.WorkingSiteId == -1)
            {
                employee.WorkingSiteId = null;
                employee.WorkingSite = null;
            }*/
                
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
            return await _context.Employees.Where(e => e.IsActive == true).Include(e => e.Company).ToListAsync();
        }

        public async Task<Employee?> GetByIdAsync(int id)
        {
            return await _context.Employees.FirstOrDefaultAsync(e => e.Id == id && e.IsActive == true);
        }

        public List<SelectListItem> GetCompaniesList()
        {
            //Necesario para llenar el DropDownList de companias al momento de crear un nuevo empleado
            var companies = _context.Companies.Where(c => c.IsActive == true).ToList();
            List<SelectListItem> lista = companies.ConvertAll(l =>
            {
                return new SelectListItem()
                {
                    Text = l.Name.ToString(),
                    Value = l.Id.ToString(),
                    Selected = false
                };
            });
            return lista;
        }

        public List<SelectListItem> GetDepartmentList()
        {
            var departments = _context.Departments.Where(d => d.IsActive == true).ToList();
            List<SelectListItem> lista = departments.ConvertAll(l =>
            {
                return new SelectListItem()
                {
                    Text = l.Name.ToString(),
                    Value = l.Id.ToString(),
                    Selected = false
                };
            });
            return lista;
        }

        public List<SelectListItem> GetWorkingSitesList()
        {
            var workingSites = _context.WorkingSites.Where(w => w.IsActive == true).ToList();
            List<SelectListItem> lista = workingSites.ConvertAll(l =>
            {
                return new SelectListItem()
                {
                    Text = l.Name.ToString(),
                    Value = l.Id.ToString(),
                    Selected = false
                };
            });
            return lista;
        }

        public List<SelectListItem> SearchByTextSelectList(string text)
        {
            var employeesList = _context.Employees.Where(e => e.Name.Contains(text) || e.LastName.Contains(text)
            || e.EmployeeNumber.Contains(text) || e.Dni.Contains(text)).ToList();
            List<SelectListItem> lista = employeesList.ConvertAll(l =>
            {
                return new SelectListItem()
                {
                    Text = l.Name + " " + l.LastName + " " + l.EmployeeNumber,
                    Value = l.Id.ToString(),
                    Selected = false
                };
            });
            return lista;

        }
        
        public async Task<IEnumerable<Employee>> SearchByText(string text)
        {
            return await _context.Employees.Where(e => e.Name.Contains(text) || e.LastName.Contains(text)
            || e.EmployeeNumber.Contains(text) || e.Dni.Contains(text)).ToListAsync();
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
