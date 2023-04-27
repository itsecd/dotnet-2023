using Microsoft.EntityFrameworkCore;

namespace RecruitmentAgency;
public class RecruitmentAgencyDbContext : DbContext
{
    public DbSet<Company>? Companies { get; set; }
    public DbSet<CompanyApplication>? CompanyApplications { get; set; }
    public DbSet<Employee>? Employees { get; set; }
    public DbSet<JobApplication>? JobApplications { get; set; }
    public DbSet<Title>? Titles { get; set; } 

    public RecruitmentAgencyDbContext(DbContextOptions options): base(options)
    {
        Database.EnsureCreated();
    }
}
