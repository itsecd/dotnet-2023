using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Enterprise.Data;

public class EnterpriseWarehouseContextFactory : IDesignTimeDbContextFactory<EnterpriseWarehouseDbContext>
{
    public EnterpriseWarehouseDbContext CreateDbContext(string[] args)
    {
        var optionsBulder = new DbContextOptionsBuilder<EnterpriseWarehouseDbContext>();
        optionsBulder.UseMySQL("Server=localhost;User=root;Database=EnterpriseWarehouseServer;Password=");

        return new EnterpriseWarehouseDbContext(optionsBulder.Options);
    }
}
