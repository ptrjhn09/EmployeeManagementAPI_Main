using EmployeeManagementAPI.DTOs;
using EmployeeManagementAPI.Interface;
using EmployeeManagementAPI.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using EmployeeManagementAPI.DTO;
namespace EmployeeManagementAPI.Controllers
{
    //THIS MEANS THIS IS A CONTROLER AND IT WILL HANDLE HTTP REQEUSTS
    [ApiController]
    [Route("apiKo/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _service;
        private readonly IMapper _mapper;
        //asdsad
        //llllllllllll
        public EmployeeController(IEmployeeService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }


        //RETURN ALL EMPLOYEES

        [Authorize(Roles = "Admin")]
        [HttpGet("GetAllEmployees")]
        public async Task<IActionResult> GetEmployees()  
        { 
            var emp = await _service.GetAllEmployeesAsync();
            return Ok(emp); //RETURN 200 OK WITH EMPLOYEES
        }

        //For Testin Only
        [Authorize]
        [HttpGet("Testing")]
        public IActionResult Test()
        {
            return Ok("Ok Success");
        }

        //RETURN EMPLOYEE BY ID
        [Authorize]
        [HttpGet ("{id}")]
        public async Task<IActionResult> GetEmployeeByIdAsync(int id)
        {
            var emp = await _service.GetEmployeeByIdAsync(id);

            if(emp == null)
            {
                return NotFound(); //RETURN 404 NOT FOUND
            }
            return Ok(emp);
        }

        //RETURN EMPLOYEE BY ID USING DTO

        [Authorize]
        [HttpGet("GetEmployeeByIdUsingDTO/{id}")]
        public async Task<IActionResult> GetEmployeeByIdAsyncdto(int id)
        {
            var emp = await _service.GetEmployeeByIdAsyncdto(id);

            if(emp == null)
            {
                return NotFound(); //RETURN 404 NOT FOUND
            }
            return Ok(emp);
        }


        //ADD NEW EMPLOYEE
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddEmployeeAsync(CreateEmployeeDto dto)
        {
           
    await _service.AddEmployeeAsync(dto);
            return Ok(); //RETURN 200 OK WITH EMPLOYEE
        }


        //UPDATE EMPLOYEE
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployeeAsync(int id, UpdateEmployeeDto dto)
        {
            var result = await _service.UpdateEmployeeAsync(id, dto);
                
                if (!result)
                {
                    return NotFound("Employee not found.");
                }
                return Ok("Employee updated successfully.");
            
        }



        //DELETE EMPLOYEE

      
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeAsync(int id)
        {
            
            await _service.DeleteEmployeeAsync(id);
            return Ok(); //RETURN 200 OK WITH EMPLOYEE);
        }
    }
}
