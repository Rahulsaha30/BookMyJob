using AdminService.Data;
using AdminService.Model;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Dto;

namespace AdminService.Services
{
  public class AdminServices : IJobPostService
  {
    private readonly AdminDbContext _context;
    public AdminServices(AdminDbContext context)
    {
      _context = context;
    }

    public async Task<Guid> CreateJobPost(JobPostDetails jobPostDetails)
    {
      var job = new JobPosting
      {
        Id = Guid.NewGuid(),
        Title = jobPostDetails.Title,
        CompanyName = jobPostDetails.CompanyName,
        Location = jobPostDetails.Location,
        JobType = jobPostDetails.JobType,
        Category = jobPostDetails.Category,
        JobFunction = jobPostDetails.JobFunction,
        CTC = jobPostDetails.CTC,
        Description = jobPostDetails.Description,
        RequiredSkills = jobPostDetails.RequiredSkills,
        AdditionalInformation = jobPostDetails.AdditionalInformation,
        Deadline = jobPostDetails.Deadline,
        PostedAt = DateTime.UtcNow,

        EligibilityCriteria = new EligibilityCriteria
        {
          Id = Guid.NewGuid(),
          MinCGPA = jobPostDetails.MinCGPA,
          NoBacklogsAllowed = jobPostDetails.NoBacklogsAllowed,
          Batch = jobPostDetails.Batch,
          Department = jobPostDetails.Department,
          Level = jobPostDetails.Level,
          Category = jobPostDetails.Category
        },
        AdditionalQuestions = new AdditionalQuestions
        {
          Id = Guid.NewGuid(),
          Question1 = jobPostDetails.Question1,
          Question2 = jobPostDetails.Question2,
          Question3 = jobPostDetails.Question3,
          Question4 = jobPostDetails.Question4,
          Question5 = jobPostDetails.Question5,
          Question6 = jobPostDetails.Question6,
          Question7 = jobPostDetails.Question7

        }
      };

      _context.jobPosting.Add(job);
      await _context.SaveChangesAsync();
      return job.Id;
    }

    public async Task<bool> DeleteJobPost(Guid id)
    {
      var job = await _context.jobPosting.FindAsync(id);
      if (job == null) return false;

      _context.jobPosting.Remove(job);
      await _context.SaveChangesAsync();
      return true;
    }


    public async Task<List<JobPostDetails>> GetAllJobPostDetails()
    {
      var job = await _context.jobPosting.Include(j => j.EligibilityCriteria).
      Include(j => j.AdditionalQuestions).ToListAsync();

      return job.Select(j => new JobPostDetails
      {
        Id = j.Id,
        Title = j.Title,
        CompanyName = j.CompanyName,
        Location = j.Location,
        JobType = j.JobType,
        Category = j.Category,
        JobFunction = j.JobFunction,
        CTC = j.CTC,
        Description = j.Description,
        RequiredSkills = j.RequiredSkills,
        AdditionalInformation = j.AdditionalInformation,
        Deadline = j.Deadline,
        PostedAt = j.PostedAt,

        MinCGPA = j.EligibilityCriteria?.MinCGPA ?? 0,
        NoBacklogsAllowed = j.EligibilityCriteria?.NoBacklogsAllowed ?? false,
        Batch = j.EligibilityCriteria?.Batch,
        Department = j.EligibilityCriteria?.Department,
        Level = j.EligibilityCriteria?.Level,


        Question1 = j.AdditionalQuestions?.Question1,
        Question2 = j.AdditionalQuestions?.Question2,
        Question3 = j.AdditionalQuestions?.Question3,
        Question4 = j.AdditionalQuestions?.Question4,
        Question5 = j.AdditionalQuestions?.Question5,
        Question6 = j.AdditionalQuestions?.Question6,
        Question7 = j.AdditionalQuestions?.Question7

      }).ToList();
      
    }

    public async Task<JobPostDetails> GetJobPostDetailsById(Guid id)
    {
      var j = await _context.jobPosting.Include(j => j.EligibilityCriteria).
      Include(j => j.AdditionalQuestions).FirstOrDefaultAsync(j => j.Id == id);

      if (j == null) return null;
         return new JobPostDetails
            {
                Id = j.Id,
                Title = j.Title,
                CompanyName = j.CompanyName,
                Location = j.Location,
                JobType = j.JobType,
                Category = j.Category,
                JobFunction = j.JobFunction,
                CTC = j.CTC,
                Description = j.Description,
                RequiredSkills = j.RequiredSkills,
                AdditionalInformation = j.AdditionalInformation,
                Deadline = j.Deadline,
                PostedAt = j.PostedAt,

                MinCGPA = j.EligibilityCriteria?.MinCGPA ?? 0,
                NoBacklogsAllowed = j.EligibilityCriteria?.NoBacklogsAllowed ?? false,
                Batch = j.EligibilityCriteria?.Batch,
                Department = j.EligibilityCriteria?.Department,
                Level = j.EligibilityCriteria?.Level,

                Question1 = j.AdditionalQuestions?.Question1,
                Question2 = j.AdditionalQuestions?.Question2,
                Question3 = j.AdditionalQuestions?.Question3,
                Question4 = j.AdditionalQuestions?.Question4,
                Question5 = j.AdditionalQuestions?.Question5,
                Question6 = j.AdditionalQuestions?.Question6,
                Question7 = j.AdditionalQuestions?.Question7
            };

    }

    public async Task<bool> UpdateJobPost(Guid id, JobPostDetails jobPostDetails)
    {
      var job = await _context.jobPosting.Include(j => j.EligibilityCriteria).
      Include(j => j.AdditionalQuestions).FirstOrDefaultAsync(j => j.Id == id);

      if (job == null) return false;

      job.Title = jobPostDetails.Title;
      job.CompanyName = jobPostDetails.CompanyName;
      job.Location = jobPostDetails.Location;
      job.JobType = jobPostDetails.JobType;
      job.Category = jobPostDetails.Category;
      job.JobFunction = jobPostDetails.JobFunction;
      job.CTC = jobPostDetails.CTC;
      job.Description = jobPostDetails.Description;
      job.RequiredSkills = jobPostDetails.RequiredSkills;
      job.AdditionalInformation = jobPostDetails.AdditionalInformation;
      job.Deadline = jobPostDetails.Deadline;

      job.EligibilityCriteria.MinCGPA = jobPostDetails.MinCGPA;
      job.EligibilityCriteria.NoBacklogsAllowed = jobPostDetails.NoBacklogsAllowed;
      job.EligibilityCriteria.Batch = jobPostDetails.Batch;
      job.EligibilityCriteria.Department = jobPostDetails.Department;
      job.EligibilityCriteria.Level = jobPostDetails.Level;
      job.EligibilityCriteria.Category = jobPostDetails.Category;

      job.AdditionalQuestions.Question1 = jobPostDetails.Question1;
      job.AdditionalQuestions.Question2 = jobPostDetails.Question2;
      job.AdditionalQuestions.Question3 = jobPostDetails.Question3;
      job.AdditionalQuestions.Question4 = jobPostDetails.Question4;
      job.AdditionalQuestions.Question5 = jobPostDetails.Question5;
      job.AdditionalQuestions.Question6 = jobPostDetails.Question6;
      job.AdditionalQuestions.Question7 = jobPostDetails.Question7;

      await _context.SaveChangesAsync();
      return true;

    }
  }
  
}