using System.ComponentModel.DataAnnotations;

namespace SharedLibrary.Dto
{
  public class UserRegisterDto
  {
    [Required]
    public string FullName { get; set; }

    [Required]
    public int RollNumber{ get; set; }
    
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
  }
}