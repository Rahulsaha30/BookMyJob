using AdminService.Data;
using AdminService.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// 1. Configure DbContext
builder.Services.AddDbContext<AdminDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. Register Service
builder.Services.AddScoped<IJobPostService, AdminService.Services.AdminServices>(); // Make sure 'AdminServices' is the actual class name

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
                Encoding.UTF8.GetBytes(secretKey))
        };
    });

// 5. Enable Authorization
builder.Services.AddAuthorization();

var app = builder.Build();

// 6. Middleware
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
