using System.ComponentModel.DataAnnotations;

namespace SharedLibrary.Dto
{
  public class JobPostDetails
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

    //eLIGIBILTY
    public double MinCGPA { get; set; }
    public bool NoBacklogsAllowed { get; set; }
    public string Batch { get; set; }
    public string Department { get; set; }

    public string Level { get; set; }

    //Aditional 
    
    public string Question1 { get; set; } = string.Empty;
    public string Question2 { get; set; }= string.Empty;
    public string Question3 { get; set; }= string.Empty;
    public string Question4 { get; set; }= string.Empty;
    public string Question5 { get; set; }= string.Empty;
    public string Question6 { get; set; }= string.Empty;
    public string Question7 { get; set; }= string.Empty;



  }
}