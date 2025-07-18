using System.ComponentModel.DataAnnotations;

namespace SharedLibrary.Dto
{
  public class UserLoginDto
  {
    [Required]
    public string Email { get; set; }

    [Required]
    public string Password{ get; set; }
  }
}