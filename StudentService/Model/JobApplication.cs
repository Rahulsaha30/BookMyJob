using System.ComponentModel.DataAnnotations;

namespace StudentService.Model
{
  public class JobApplication
  {
    [Required]
    public Guid Id { get; set; }
    [Required]
    public Guid JobId { get; set; }
    [Required]
    public Guid StudentId { get; set; }
    public DateTime AppliedAT { get; set; } = DateTime.UtcNow;
    public string Status { get; set; } = "Pending";
  }
  
}