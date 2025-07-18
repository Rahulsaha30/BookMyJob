using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Consul;
using SharedLibrary.Consul; // Adjust this if your RegisterConsul file is in another namespace
using StudentService.Data;
using StudentService.Service; // If you have any service interfaces to inject

var builder = WebApplication.CreateBuilder(args);

// 1. Configure DbContext
builder.Services.AddDbContext<StudentDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<JobServiceClient>();
// 2. Register Application Services
builder.Services.AddScoped<IstudetService, StudentService.Service.StudentServices>(); // Example service, optional
builder.Services.AddHttpClient();

builder.Services.AddScoped<ConsulServiceResolver>();

// 3. Add Controllers
builder.Services.AddControllers();

// 4. Configure JWT Authentication
var secretKey = builder.Configuration["JwtSettings:SecretKey"];
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(secretKey!))
        };
    });

// 5. Enable Authorization
builder.Services.AddAuthorization();

// 6. Add Consul Client
builder.Services.AddSingleton<IConsulClient, ConsulClient>(p => new ConsulClient(cfg =>
{
    cfg.Address = new Uri("http://localhost:8500");
}));

var app = builder.Build();

//app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

// 🔚 Register this service in Consul
app.RegisterConsul(app.Configuration);

app.Run();
