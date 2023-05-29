using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Realtor;
public class RealtorContextFactory : IDesignTimeDbContextFactory<RealtorDbContext>
{
    public RealtorDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<RealtorDbContext>();
        optionsBuilder.UseMySQL("Realtor");

        return new RealtorDbContext(optionsBuilder.Options);
    }
}
