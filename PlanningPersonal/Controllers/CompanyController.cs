﻿using Microsoft.AspNetCore.Mvc;
using PlanningPersonal.Interfaces;
using PlanningPersonal.Models;
using PlanningPersonal.DTOs;
using AutoMapper;

namespace PlanningPersonal.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public CompanyController(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Company> companies = await _companyRepository.GetAllAsync();
            IEnumerable<CompanyDto> companiesDto = _mapper.Map<IEnumerable<CompanyDto>>(companies);
            return View(companiesDto);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CompanyDto companyDto)
        {
            var company = _mapper.Map<Company>(companyDto);
            if (!ModelState.IsValid) 
            { 
                return View(companyDto); 
            }
            _companyRepository.Add(company);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var company = await _companyRepository.GetByIdAsync(id);
            if (company != null)
            {
                company.IsActive = false;
                _companyRepository.Save();
            } 
            return RedirectToAction("Index");
        }
    }
}
