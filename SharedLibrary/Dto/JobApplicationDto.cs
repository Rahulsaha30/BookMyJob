using System.ComponentModel.DataAnnotations;

namespace SharedLibrary.Dto
{
  public class JobApplicationDto
  {
     [Required]
   public Guid Id { get; set; }
    [Required]
    public Guid JobId { get; set; }
     [Required]
    public Guid StudentId { get; set; }
    public DateTime AppliedAt { get; set; }
    public string Status { get; set; }
  }
}