using AdminService.Data;
using AdminService.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Consul;
using SharedLibrary.Consul;
using AdminService.Service; // Update this if your RegisterConsul class is in a different namespace

var builder = WebApplication.CreateBuilder(args);

// 1. Configure DbContext
builder.Services.AddDbContext<AdminDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. Register Service
builder.Services.AddScoped<IJobPostService, AdminServices>(); // Make sure 'AdminServices' is the actual class name

builder.Services.AddScoped<ConsulServiceResolver>();

// 🔹 Add Consul Client
builder.Services.AddSingleton<IConsulClient, ConsulClient>(p => new ConsulClient(cfg =>
{
    cfg.Address = new Uri("http://localhost:8500");
}));

// 3. Add Controllers
builder.Services.AddControllers();

// 4. Configure JWT Auth
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

var app = builder.Build();

// 6. Middleware
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

// 🔹 Register this service with Consul
app.RegisterConsul(app.Configuration);

app.Run();
