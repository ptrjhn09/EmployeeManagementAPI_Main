using EmployeeManagementAPI.Data;
using EmployeeManagementAPI.Interface;
using EmployeeManagementAPI.Mapping;
using EmployeeManagementAPI.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Scalar.AspNetCore;
using Microsoft.AspNetCore.OpenApi;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
  .AddJwtBearer(options =>
  {
      options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
      {
          ValidateIssuer = false,
          ValidIssuer = builder.Configuration["JWTPractice:Issuer"],
          ValidateAudience = false,
          ValidAudience = builder.Configuration["JWTPractice:Audience"],
          ValidateLifetime = true,
          IssuerSigningKey = new SymmetricSecurityKey(
              Encoding.UTF8.GetBytes("A7xP9mQ2vR5tY8uW1kL4nB6cD3eF7gH9jK2pS5zX8nV1mC4r"))
      };
  });

builder.Services.AddAuthorization();


builder.Services.AddDbContext<ApplicationDBContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnectionAHU")));


builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddAutoMapper(cfg =>
{
},typeof(ProfileMapping).Assembly);
builder.Services.AddOpenApi();
var app = builder.Build();



if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}


app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
