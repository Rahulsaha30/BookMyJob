using AuthService.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Helper;

namespace AuthService.Data
{
  public class AppDbContext : DbContext
  {

    public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options) { }
    public DbSet<User> users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);

    var adminUser = new User
    {
        Id = new Guid("11111111-1111-1111-1111-111111111111"),
        FullName = "Admin User",
        Email = "admin@bookmyjob.com",
        Password = PasswordHash.Hash("Admin@123"), 
        Role = "Admin"
    };

    modelBuilder.Entity<User>().HasData(adminUser);
}

    
   
  }
}