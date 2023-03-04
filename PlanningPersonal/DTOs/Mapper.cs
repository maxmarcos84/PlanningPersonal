using AutoMapper;
using PlanningPersonal.Data;
using PlanningPersonal.Interfaces;
using PlanningPersonal.Models;

namespace PlanningPersonal.DTOs
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<CompanyDto, Company>();
            CreateMap<Company, CompanyDto>();
            CreateMap<WorkingSiteDto, WorkingSite>();
            CreateMap<WorkingSite, WorkingSiteDto>();
            CreateMap<DepartmentDto, Department>();
            CreateMap<Department, DepartmentDto>();
            CreateMap<Employee, EmployeeDto>();
            CreateMap<CreateEmployeeDto, Employee>();               
        }
        
    }
}
