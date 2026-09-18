using EmployeeManagementAPI.DTO;
using EmployeeManagementAPI.DTOs;
using EmployeeManagementAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementAPI.Interface
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetAllEmployeesAsync();
        Task AddEmployeeAsync(CreateEmployeeDto dto);
        Task<bool> UpdateEmployeeAsync(int id, UpdateEmployeeDto dto);
        Task DeleteEmployeeAsync(int id);

        Task<Employeedto> GetEmployeeByIdAsyncdto(int id);

    }
}
