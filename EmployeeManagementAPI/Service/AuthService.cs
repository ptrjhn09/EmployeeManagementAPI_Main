using EmployeeManagementAPI.Data;
using EmployeeManagementAPI.DTO;
using EmployeeManagementAPI.Model;
using EmployeeManagementAPI.Interface;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using AutoMapper;
using System.Text;
namespace EmployeeManagementAPI.Service
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;

        public AuthService(ApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<string> LogInMethod (LoginRequest request)
        {
            var user = await _context.UserDB.FirstOrDefaultAsync(p => p.Username == request.UserName && p.Password == request.Password); 
            if (user == null)
            {
                return "User not found";
            }

            return await GenerateToken(user);
        }

       
        public async Task<string> GenerateToken(User user)
        {

            var Claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role),

            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("A7xP9mQ2vR5tY8uW1kL4nB6cD3eF7gH9jK2pS5zX8nV1mC4r")
             );

            var credentials = new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256
            );

            var token = new JwtSecurityToken(
                claims: Claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<string> Register(RegisterUserDto dto)
        {
            var user = _mapper.Map<User>(dto);
            
            _context.UserDB.Add(user);
            await _context.SaveChangesAsync();
            return "User Registered Successfully";

        }
    }
}
