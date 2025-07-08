using SharedLibrary.Dto;

namespace AdminService.Services
{
  public interface IJobPostService
  {
    Task<Guid> CreateJobPost(JobPostDetails jobPostDetails);
    Task<bool> UpdateJobPost(Guid id,JobPostDetails jobPostDetails);
    Task<bool> DeleteJobPost(Guid id);
    Task<List<JobPostDetails>> GetAllJobPostDetails();
    Task<JobPostDetails> GetJobPostDetailsById(Guid id);
  }
}