using Microsoft.EntityFrameworkCore;
using StudentService.Model;

namespace StudentService.Data
{
  public class StudentDbContext : DbContext
  {
    public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options) { }
    
    public DbSet<JobApplication> jobApplications{ get; set; }
  }
}