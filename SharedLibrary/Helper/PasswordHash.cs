using System.Security.Cryptography;
using System.Text;

namespace SharedLibrary.Helper
{
  public static class PasswordHash
  {
    public static string Hash(string Password)
    {
      using var sha256 = SHA256.Create();
      var bytes = Encoding.UTF8.GetBytes(Password);
      var hash = sha256.ComputeHash(bytes);
      return Convert.ToBase64String(hash);
    }
  }
}