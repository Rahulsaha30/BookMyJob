using System.ComponentModel.DataAnnotations;

namespace AdminService.Model
{
  public class EligibilityCriteria
  {
    [Key]
    public Guid Id { get; set; }

    public double MinCGPA { get; set; }
    public bool NoBacklogsAllowed { get; set; }
    public string Batch { get; set; } // e.g., 2026 Graduating Batch
    public string Department { get; set; } // optional
    public string Category { get; set; } // e.g., IT
    public string Level { get; set; }

    public Guid JobPostingId { get; set; }
    
    public JobPosting jobPosting{ get; set; }
  }
}