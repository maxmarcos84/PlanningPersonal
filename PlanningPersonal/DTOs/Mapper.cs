using AutoMapper;
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
        }
    }
}
