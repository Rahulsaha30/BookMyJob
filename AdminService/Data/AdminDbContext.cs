using AdminService.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace AdminService.Data
{
  public class AdminDbContext : DbContext
  {
    public AdminDbContext(DbContextOptions<AdminDbContext> options) : base(options) { }

    public DbSet<JobPosting> jobPosting { get; set; }
    public DbSet<EligibilityCriteria> EligibilityCriteria { get; set; }
    public DbSet<AdditionalQuestions> AdditionalQuestions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<JobPosting>().
      HasOne(j => j.EligibilityCriteria).
      WithOne(i => i.jobPosting).
      HasForeignKey<EligibilityCriteria>(i => i.JobPostingId)
      .OnDelete(DeleteBehavior.Cascade);

         modelBuilder.Entity<JobPosting>()
                .HasOne(j => j.AdditionalQuestions)
                .WithOne(aq => aq.jobPosting)
                .HasForeignKey<AdditionalQuestions>(aq => aq.JobPostingId)
                .OnDelete(DeleteBehavior.Cascade);

      base.OnModelCreating(modelBuilder);
    }
  }
}

