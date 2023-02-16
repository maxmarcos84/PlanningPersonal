using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PlanningPersonal.DTOs;
using PlanningPersonal.Interfaces;
using PlanningPersonal.Models;

namespace PlanningPersonal.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _departmentRepo;
        private readonly IMapper _mapper;

        public DepartmentController(IDepartmentRepository departmentRepo, IMapper mapper)
        {
            _departmentRepo = departmentRepo;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Department> departments = await _departmentRepo.GetAllAsync();
            IEnumerable<DepartmentDto> departmentsDto = _mapper.Map<IEnumerable<DepartmentDto>>(departments);
            return View(departmentsDto);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DepartmentDto departmentDto)
        {
            var department = _mapper.Map<Department>(departmentDto);
            if (!ModelState.IsValid)
            {
                return View(departmentDto);
            }
            _departmentRepo.Add(department);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var department = await _departmentRepo.GetByIdAsync(id);
            if(department != null)
            {
                department.IsActive = false;
                _departmentRepo.Save();
            }
            return RedirectToAction("Index");
        }

    }
}
