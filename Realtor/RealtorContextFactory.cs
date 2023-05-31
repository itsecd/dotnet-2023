using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Realtor;
public class RealtorContextFactory : IDesignTimeDbContextFactory<RealtorDbContext>
{
    public RealtorDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<RealtorDbContext>();
        optionsBuilder.UseMySQL("Server=127.0.0.1;Uid=root;Database=Realtor;Pwd=7032");
        return new RealtorDbContext(optionsBuilder.Options);
    }
}
