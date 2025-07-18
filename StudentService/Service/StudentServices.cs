using SharedLibrary.Dto;
using StudentService.Data;

namespace StudentService.Service
{
  public class StudentServices : IstudetService
  {
    private readonly StudentDbContext _context;
    private readonly JobServiceClient _jobServiceClient;

    public StudentServices(StudentDbContext context ,JobServiceClient jobServiceClient)
    {
      _context = context;
      _jobServiceClient = jobServiceClient;
      
    }

    public async Task<string> ApplyJob(Guid JobId, Guid StudentId)
    {
      if (!await _jobServiceClient.JobExistsAsync(JobId))
      {
        return "job does not exist";
      }
      if (_context.jobApplications.Any(j => j.JobId == JobId && j.StudentId == StudentId))
      {
        return "Already applied";

      }

      _context.jobApplications.Add(new Model.JobApplication
      {
        Id = Guid.NewGuid(),
        JobId = JobId,
        StudentId = StudentId,
        AppliedAT = DateTime.UtcNow
      });
         await _context.SaveChangesAsync();
        return "Applied successfully";

    }

    public async Task<List<JobPostDetails>> GetallJob()
    {
      return await _jobServiceClient.Getalljobs();
    }
  }
}