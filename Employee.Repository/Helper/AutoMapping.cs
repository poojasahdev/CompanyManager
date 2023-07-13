using AutoMapper;
using Company.Core.Models;
using Company.Core.Repository;
using Company.Repository.Entities;

namespace Company.Repository.Helper
{
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
            CreateMap<Employee, EmployeeResponse>();
            CreateMap<AddEmployeeRequest, Employee>();
            CreateMap<UpdateEmployeeRequest, Employee>();

        }
    }
}
