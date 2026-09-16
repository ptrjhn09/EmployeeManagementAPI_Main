using AutoMapper;
using EmployeeManagementAPI.Data;
using EmployeeManagementAPI.DTO;
using EmployeeManagementAPI.DTOs;
using EmployeeManagementAPI.Interface;
using EmployeeManagementAPI.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
namespace EmployeeManagementAPI.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;
        public EmployeeService(ApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task AddEmployeeAsync(CreateEmployeeDto dto)
        {
            var employee = _mapper.Map<Employee>(dto);
            await _context.EmployeesDB.AddAsync(employee);
            await _context.SaveChangesAsync();

        }


        public async Task DeleteEmployeeAsync(int id)
        {
            var emp = _context.EmployeesDB.FirstOrDefault(e => e.ID == id);
            if (emp != null)
            {
                _context.EmployeesDB.Remove(emp);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            var allEmp = await _context.EmployeesDB.ToListAsync();
            return allEmp;

        }
        public async Task<Employeedto> GetEmployeeByIdAsyncdto(int id)
        {
            var emp = await _context.EmployeesDB.FindAsync(id);

            var dto = _mapper.Map<Employeedto>(emp);
            return dto;


        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await _context.EmployeesDB.FirstAsync(e => e.ID == id);
            
        }

        public async Task<bool> UpdateEmployeeAsync(int id, UpdateEmployeeDto dto)
        {
            var emp = await _context.EmployeesDB.FindAsync(id);

            if (emp != null)
            {
                _mapper.Map(dto, emp);

                await _context.SaveChangesAsync();

                return true;
            }

            return false;
        }
    }
}



