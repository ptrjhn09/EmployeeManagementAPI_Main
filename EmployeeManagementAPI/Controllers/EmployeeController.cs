using EmployeeManagementAPI.DTOs;
using EmployeeManagementAPI.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using EmployeeManagementAPI.DTO;
namespace EmployeeManagementAPI.Controllers
{
    //THIS MEANS THIS IS A CONTROLER AND IT WILL HANDLE HTTP REQEUSTS
    [ApiController]
    [Route("api/employees")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _service;
        private readonly IMapper _mapper;
        private readonly ILogger<EmployeeController> _logging;

        public EmployeeController(IEmployeeService service, IMapper mapper, ILogger<EmployeeController>logger)
        {
            _service = service;
            _mapper = mapper;
            _logging = logger;
        }


        [Authorize(Roles = "Admin, admin")]
        [HttpGet]
        public async Task<IActionResult> GetEmployees()  
        {
            
            var emp = await _service.GetAllEmployeesAsync();
            if (emp == null)
            {
                return NoContent();
            }
            return Ok(emp); 
        }

        [Authorize]
        [HttpGet("Testing")]
        public IActionResult Test()
        {
            _logging.LogInformation("The user Test the testing");
            return Ok("Ok Success");
        }


        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeByIdAsyncdto(int id)
        {
            var emp = await _service.GetEmployeeByIdAsyncdto(id);

            if(emp == null)
            {
                return NotFound(); 
            }
            return Ok(emp);
        }


        [Authorize(Roles = "Admin, admin")]
        [HttpPost]
        public async Task<IActionResult> AddEmployeeAsync(CreateEmployeeDto dto)
        {
            _logging.LogInformation("The User succesfuly add new Employee");
            await _service.AddEmployeeAsync(dto);
            return Ok("Add Succesfully"); 
        }


        [Authorize(Roles = "Admin, admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployeeAsync(int id, UpdateEmployeeDto dto)
        {
            _logging.LogInformation($"the User with ID {id} is succefully update");
            var result = await _service.UpdateEmployeeAsync(id, dto);
                
                if (!result)
                {
                    return NotFound("Employee not found.");
                }
                return Ok("Employee updated successfully.");
            
        }

        [Authorize(Roles = "Admin, admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeAsync(int id)
        {
            _logging.LogWarning($"User with ID {id} Successful Deleted");
            await _service.DeleteEmployeeAsync(id);
            return Ok(); 
        }
    }
}
