using AuthService.Data;
using SharedLibrary.Dto;
using AuthService.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Http.HttpResults;
using SharedLibrary.Helper;

namespace AuthService.Services
{
  public class AuthService : IAuthService
  {
    private readonly AppDbContext _context;
    private readonly IConfiguration _configure;

    public AuthService(AppDbContext context, IConfiguration configuration)
    {
      _context = context;
      _configure = configuration;
    }

     public async Task<string> Register(UserRegisterDto userRegisterDto)
    {
      if (await _context.users.AnyAsync(e => e.Email == userRegisterDto.Email))
      {
        return "Email Already Exists";
      }

      
      var User = new User
      {
        Id = Guid.NewGuid(),
        FullName = userRegisterDto.FullName,
        RollNumber = userRegisterDto.RollNumber,
        Email = userRegisterDto.Email,
        Password = PasswordHash.Hash(userRegisterDto.Password),
        Role="User"
      };

       _context.users.Add(User);
      await _context.SaveChangesAsync();

      return "User Registered";
    }



    public async Task<string> Login(UserLoginDto userLoginDto)
    {
      var hashed = PasswordHash.Hash(userLoginDto.Password);

      var user = await _context.users.FirstOrDefaultAsync
      (u => u.Email == userLoginDto.Email.ToLower()
      && u.Password == hashed);

      if (user == null)
      {
        return "Invalid";
      }
      var claims = new List<Claim>
    {
      new Claim(ClaimTypes.Name,user.FullName),
      new Claim("UserId",user.Id.ToString())
    };
      foreach (var role in user.Role.Split(','))
        claims.Add(new Claim(ClaimTypes.Role, role.Trim()));

      var Token = JwtTokenGenerator.Generate(_configure, claims, 30);

     return Token;
    }




    public async Task<string> UpdateProfile(UpdateProfileDto updateProfileDto, Guid userId)
    {
      var user = await _context.users.FindAsync(userId);
      if (user == null) return "user not found";

      user.DateOfBirth = updateProfileDto.DateOfBirth;
      user.Gender = updateProfileDto.Gender;
      user.College = updateProfileDto.College;
      user.PermanentAddress = updateProfileDto.PermanentAddress;
      user.CurrentAddress = updateProfileDto.CurrentAddress;
      user.FathersName = updateProfileDto.FathersName;
      user.MothersName = updateProfileDto.MothersName;
      user.FathersMobile = updateProfileDto.FathersMobile;
      user.MothersMobile = updateProfileDto.MothersMobile;
      user.AlternateMobile = updateProfileDto.AlternateMobile;
      user.WhatsappNumber = updateProfileDto.WhatsappNumber;
      user.Nationality = updateProfileDto.Nationality;
      user.AadhaarNumber = updateProfileDto.AadhaarNumber;
      user.PassportNumber = updateProfileDto.PassportNumber;
      user.PancardNumber = updateProfileDto.PancardNumber;
      user.RegulationDocumentLink = updateProfileDto.RegulationDocumentLink;
      user.IsProfileComplete = true;

      await _context.SaveChangesAsync();
      return "Profile updated";
    }
  }

}