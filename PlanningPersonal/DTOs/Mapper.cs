using AutoMapper;
using PlanningPersonal.Models;

namespace PlanningPersonal.DTOs
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<CompanyDto, Company>();
        }
    }
}
