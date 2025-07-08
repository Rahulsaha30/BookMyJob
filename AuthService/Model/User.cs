using System.ComponentModel.DataAnnotations;

namespace AuthService.Model
{
  public class User
  {
    [Key]
    public Guid Id { get; set; }
    [Required]
    public string FullName { get; set; }

    [Required]
    public int RollNumber { get; set; }

    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }


    // Profile fields 
    public DateTime? DateOfBirth { get; set; }
    public string Gender { get; set; } = string.Empty;
    public string College { get; set; } = string.Empty;
    public string PermanentAddress { get; set; } = string.Empty;
    public string CurrentAddress { get; set; } = string.Empty;
    public string FathersName { get; set; } = string.Empty;
    public string MothersName { get; set; } = string.Empty;
    public string FathersMobile { get; set; } = string.Empty;
    public string MothersMobile { get; set; } = string.Empty;
    public string AlternateMobile { get; set; } = string.Empty;
    public string WhatsappNumber { get; set; } = string.Empty;
    public string Nationality { get; set; } = string.Empty;
    public string AadhaarNumber { get; set; } = string.Empty;
    public string PassportNumber { get; set; } = string.Empty;
    public string PancardNumber { get; set; } = string.Empty;
    public string RegulationDocumentLink { get; set; } = string.Empty;

    public bool IsProfileComplete { get; set; } = false;

    public string Role { get; set; } = string.Empty;
  }
}