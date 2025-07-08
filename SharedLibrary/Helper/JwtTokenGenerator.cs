using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace SharedLibrary.Helper
{
  public static class JwtTokenGenerator
  {
    public static string Generate(IConfiguration config, List<Claim> claims, int ExpiryTime)
    {
      var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JwtSettings:SecretKey"]!));
      var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
      var token = new JwtSecurityToken
      (
         claims: claims,
        expires: DateTime.UtcNow.AddMinutes(ExpiryTime),
        signingCredentials:creds
      );
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
  }
}