using System.ComponentModel.DataAnnotations;

namespace AdminService.Model
{
  public class JobPosting
  {
    [Key]
    public Guid Id { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public string CompanyName { get; set; }
    [Required]
    public string Location { get; set; }
    [Required]
    public string JobType { get; set; }
    [Required]
    public string Category { get; set; }
    [Required]
    public string JobFunction { get; set; }
    [Required]
    public decimal CTC { get; set; }

    public string Description { get; set; } = string.Empty;

    public string RequiredSkills { get; set; } = string.Empty;

    public string AdditionalInformation { get; set; } = string.Empty;

    [Required]
    public DateTime Deadline { get; set; }
    public DateTime PostedAt { get; set; } = DateTime.UtcNow;

     public EligibilityCriteria EligibilityCriteria { get; set; }
    public AdditionalQuestions AdditionalQuestions { get; set; }
      
    
  }
}