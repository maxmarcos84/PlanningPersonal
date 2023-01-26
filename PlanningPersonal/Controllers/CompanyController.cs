using Microsoft.AspNetCore.Mvc;
using PlanningPersonal.Interfaces;
using PlanningPersonal.Models;

namespace PlanningPersonal.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyController(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Company> companies = await _companyRepository.GetAllAsync();
            return View(companies);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Company company)
        {
            if (!ModelState.IsValid) { return View(company); }
            _companyRepository.Add(company);
            return RedirectToAction("Index");
        }
    }
}
