using EmployeeManagementAPI.Data;
using EmployeeManagementAPI.DTO;
using EmployeeManagementAPI.Interface;
using EmployeeManagementAPI.Model;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Security.AccessControl;


namespace EmployeeManagementAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
      

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }


        [HttpPost("Login")]

        public async Task<IActionResult> LoginKo(LoginRequest request)
        {
            var token = await _authService.LogInMethod(request);
            return Ok(token);
        }

        [HttpPost("Register")]

        public async Task<IActionResult> Register(RegisterUserDto dto)
        {
            var result = await _authService.Register(dto);
            return Ok(result);
        }

    }

}
