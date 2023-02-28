using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlanningPersonal.DTOs;
using PlanningPersonal.Interfaces;
using PlanningPersonal.Models;

namespace PlanningPersonal.Controllers
{
    public class WorkingSiteController : Controller
    {
        private readonly IWorkingSiteRepository _workingSiteRepository;
        private readonly IMapper _mapper;

        public WorkingSiteController(IWorkingSiteRepository workingSiteRepository, IMapper mapper)
        {
            _workingSiteRepository = workingSiteRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<WorkingSite> workingSites = await _workingSiteRepository.GetAllAsync();
            IEnumerable<WorkingSiteDto> workingSiteDtos = _mapper.Map<IEnumerable<WorkingSiteDto>>(workingSites);
            return View(workingSiteDtos);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(WorkingSiteDto workingSiteDto)
        {
            var workingSite = _mapper.Map<WorkingSite>(workingSiteDto);
            if (!ModelState.IsValid)
            {
                return View(workingSiteDto);
            }
            _workingSiteRepository.Add(workingSite);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var workingSite = await _workingSiteRepository.GetByIdAsync(id);
            if(workingSite != null)
            {
                workingSite.IsActive = false;
                _workingSiteRepository.Save();
            }
            return RedirectToAction("Index");     
        }

    }
}
