using Microsoft.EntityFrameworkCore;
using EmployeeManagementAPI.Model;
namespace EmployeeManagementAPI.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        public DbSet <Employee> EmployeesDB { get; set; }
        public DbSet<User> UserDB { get; set; }

    }
}
