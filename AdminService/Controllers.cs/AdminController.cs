using AdminService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Dto;

namespace AdminService.Controllers
{
  [ApiController]
  [Route("api/admin/JobPost")]
  [Authorize(Roles = "Admin")]
  public class AdminController : ControllerBase
  {
    private readonly IJobPostService _jobPostService;
    public AdminController(IJobPostService jobPostService)
    {
      _jobPostService = jobPostService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateJob([FromBody] JobPostDetails jobPostDetails)
        {
            var jobId = await _jobPostService.CreateJobPost(jobPostDetails);
            return CreatedAtAction(nameof(GetJobById), new { id = jobId }, new { Id = jobId });
        }

       
        [HttpGet]
        public async Task<IActionResult> GetAllJobs()
        {
            var jobs = await _jobPostService.GetAllJobPostDetails();
            return Ok(jobs);
        }

     
        [HttpGet("{id}")]
        public async Task<IActionResult> GetJobById(Guid id)
        {
            var job = await _jobPostService.GetJobPostDetailsById(id);
            if (job == null) return NotFound();
            return Ok(job);
        }

      
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateJob(Guid id, [FromBody] JobPostDetails jobPostDetails)
        {
            var result = await _jobPostService.UpdateJobPost(id, jobPostDetails);
            if (!result) return NotFound();
            return NoContent();
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJob(Guid id)
        {
            var result = await _jobPostService.DeleteJobPost(id);
            if (!result) return NotFound();
            return NoContent();
        }
  }
}