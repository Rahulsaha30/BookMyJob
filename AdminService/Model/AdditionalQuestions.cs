using System.ComponentModel.DataAnnotations;

namespace AdminService.Model
{
  public class AdditionalQuestions
  {
    [Key]
    public Guid Id { get; set; }

    public string Question1 { get; set; } = string.Empty;
    public string Question2 { get; set; }= string.Empty;
    public string Question3 { get; set; }= string.Empty;
    public string Question4 { get; set; }= string.Empty;
    public string Question5 { get; set; }= string.Empty;
    public string Question6 { get; set; }= string.Empty;
    public string Question7 { get; set; }= string.Empty;
         
   public Guid JobPostingId{ get; set; }
   public JobPosting jobPosting { get; set; }
  }
}