using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Company.Domain;


public class CompanyContextFactory : IDesignTimeDbContextFactory<CompanyDbContext>
{
    public CompanyDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<CompanyDbContext>();
        //optionsBuilder.UseMySQL("Server=127.0.0.1;Uid=root;Database=Company;Pwd=Root123456");

        return new CompanyDbContext(optionsBuilder.Options);
    }
}
