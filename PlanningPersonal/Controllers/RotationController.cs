using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlanningPersonal.DTOs;
using PlanningPersonal.Interfaces;
using PlanningPersonal.Models;
using System.Dynamic;

namespace PlanningPersonal.Controllers
{
    public class RotationController : Controller
    {
        private readonly IRotationRepository _rotationRepo;
        private readonly IEmployeeRepository _employeeRepo;
        private readonly IMapper _mapper;

        public RotationController(IRotationRepository repository, 
            IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _rotationRepo = repository;
            _employeeRepo = employeeRepository;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> getEmployees(string search)
        {
            //var res = await _employeeRepo.SearchByText(search);
            var res = _employeeRepo.SearchByTextSelectList(search);
            
            return PartialView("_EmployeesResults", res);
        }

        public async Task<IActionResult> Create(string id)
        {
            if(id != null)
            {
                int idEmployee = 0;
                if (int.TryParse(id, out idEmployee))
                {
                    Employee employee = await _employeeRepo.GetByIdAsync(idEmployee);                    
                    if (employee != null)
                    {
                        var rotation = new Rotation();
                        ViewBag.EmployeeId = employee.Id.ToString();
                        ViewBag.EmployeeName = employee.Name;
                        ViewBag.EmployeeLastName = employee.LastName;
                        ViewBag.EmployeeNumber = employee.EmployeeNumber;
                        return View(rotation);
                    }                    
                }                 
            }            
            return View();
        }
    }
}
