using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlanningPersonal.DTOs;
using PlanningPersonal.Interfaces;
using PlanningPersonal.Models;
using PlanningPersonal.Repository;

namespace PlanningPersonal.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Employee> employees = await _employeeRepository.GetAllAsync();
            IEnumerable<EmployeeDto> employeeDtos = _mapper.Map<IEnumerable<EmployeeDto>>(employees);
            return View(employeeDtos);
        }

        public IActionResult Create()
        {
            ViewBag.companiesItem = _employeeRepository.GetCompaniesList();
            ViewBag.departmentItem = _employeeRepository.GetDepartmentList();
            ViewBag.sitesItem = _employeeRepository.GetWorkingSitesList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateEmployeeDto employeeDto)
        {
            var employee = _mapper.Map<Employee>(employeeDto);           

            if (!ModelState.IsValid)
            {
                ViewBag.companiesItem = _employeeRepository.GetCompaniesList();
                ViewBag.departmentItem = _employeeRepository.GetDepartmentList();
                ViewBag.sitesItem = _employeeRepository.GetWorkingSitesList();
                return View(employeeDto);
            }
            _employeeRepository.Add(employee);
            return RedirectToAction("Index");
        }
    }
}
