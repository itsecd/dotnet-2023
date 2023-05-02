using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace PharmacyCityNetwork;
public class PharmacyCityNetworkContextFactory : IDesignTimeDbContextFactory<PharmacyCityNetworkDbContext>
{
    public PharmacyCityNetworkDbContext CreateDbContext(string[] args)
    {
        var optionsBilder = new DbContextOptionsBuilder<PharmacyCityNetworkDbContext>();
        optionsBilder.UseMySQL("PharmacyCityNetwork");

        return new PharmacyCityNetworkDbContext(optionsBilder.Options);
    }
}
