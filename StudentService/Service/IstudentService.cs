using SharedLibrary.Dto;
using StudentService.Model;

namespace StudentService.Service
{
  public interface IstudetService
  {
    Task<List<JobPostDetails>> GetallJob();
    Task<string> ApplyJob(Guid JobId, Guid StudentId);
    
  }
}