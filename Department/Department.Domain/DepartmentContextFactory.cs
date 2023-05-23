using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Department.Domain;
public class DepartmentContextFactory : IDesignTimeDbContextFactory<DepartmentDbContext>
{
    public DepartmentDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DepartmentDbContext>();
        optionsBuilder.UseMySQL("Server=127.0.0.1;Uid=root;Database=Department;Pwd=12345");

        return new DepartmentDbContext(optionsBuilder.Options);
    }
}
