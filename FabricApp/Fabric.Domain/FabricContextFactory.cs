using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Fabrics.Domain;
public class FabricContextFactory : IDesignTimeDbContextFactory<FabricsDbContext>
{
    public FabricsDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<FabricsDbContext>();
        optionsBuilder.UseMySQL("Server=127.0.0.1;Uid=root;Database=Fabrics;Pwd=passw0rd");
        return new FabricsDbContext(optionsBuilder.Options);
    }
}
