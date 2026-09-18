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
            //tells AutoMapper to convert one object into >> another object
            CreateMap<Employee, Employeedto>();
            CreateMap<UpdateEmployeeDto, Employee>();
            CreateMap<RegisterUserDto, User>();
            CreateMap<CreateEmployeeDto, Employee>();
        }
    }
}
