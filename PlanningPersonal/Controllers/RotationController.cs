using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlanningPersonal.Interfaces;
using PlanningPersonal.Models;

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

        public IActionResult Create(string id)
        {
            if(id != null)
            {
                ViewBag.id = id.ToString();
            }            
            return View();
        }
    }
}
