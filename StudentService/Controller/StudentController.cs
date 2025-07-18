using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace StudentService.Service
{
  [ApiController]
  [Route("api/student")]
  [Authorize(Roles ="User")]
  public class StudentController : ControllerBase
  {
    private readonly IstudetService _studentservices;
    public StudentController(IstudetService studentServices)
    {
      _studentservices = studentServices;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
      var jobs = await _studentservices.GetallJob();
      return Ok(jobs);
    }
    [HttpPost("apply")]
    public async Task<IActionResult> Apply([FromBody] Guid jobId)
    {
       var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == "UserId");
      if (userIdClaim == null)
        return Unauthorized("UserId not found in token");

      var studentId = Guid.Parse(userIdClaim.Value);

      var result = await _studentservices.ApplyJob(jobId, studentId);
      return Ok(new { message = result });

    }


  }
}