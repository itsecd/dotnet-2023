using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace RentalService.Domain;

public class RentalServiceContextFactory : IDesignTimeDbContextFactory<RentalServiceDbContext>
{
    public RentalServiceDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<RentalServiceDbContext>();
        optionsBuilder.UseMySQL("Server=localhost;Uid=root;DataBase=RentalService;Pwd=");
        return new RentalServiceDbContext(optionsBuilder.Options);
    }
}