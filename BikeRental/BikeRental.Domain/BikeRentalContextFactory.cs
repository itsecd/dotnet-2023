using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BikeRental.Domain;

public class BikeRentalContextFactory : IDesignTimeDbContextFactory<BikeRentalDbContext>
{
    public BikeRentalDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<BikeRentalDbContext>();
        optionsBuilder.UseMySQL("Server=127.0.0.1;Uid=root;Database=BikeRental;Pwd=12345");

        return new BikeRentalDbContext(optionsBuilder.Options); 
    }
}
