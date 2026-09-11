using EmployeeManagementAPI.DTO;
using EmployeeManagementAPI.Model;
using System.Globalization;

namespace EmployeeManagementAPI.Interface
{
    public interface IAuthService
    {

        Task<string> GenerateToken(User user);

        Task<String> Register (RegisterUserDto dto);
        Task<String> LogInMethod(LoginRequest request);
    }
}





