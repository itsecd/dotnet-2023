using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace RecruitmentAgency;
public class RecruitmentAgencyContextFactory : IDesignTimeDbContextFactory<RecruitmentAgencyDbContext>
{
    public RecruitmentAgencyDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<RecruitmentAgencyDbContext>();
        optionsBuilder.UseMySQL("Server=127.0.0.1;Uid=root;Database=RecruitmentAgency;Pwd=");

        return new RecruitmentAgencyDbContext(optionsBuilder.Options);
    }
}
