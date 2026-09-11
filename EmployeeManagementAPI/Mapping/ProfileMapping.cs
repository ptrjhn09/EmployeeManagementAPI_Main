using AutoMapper;
using EmployeeManagementAPI.DTO;
using EmployeeManagementAPI.DTOs;
using EmployeeManagementAPI.Model;
namespace EmployeeManagementAPI.Mapping
{
    public class ProfileMapping : Profile
    {
        public ProfileMapping() 
        {
            CreateMap<Employee, Employeedto>();
            CreateMap<UpdateEmployeeDto, Employee>();
        }
    }
}
