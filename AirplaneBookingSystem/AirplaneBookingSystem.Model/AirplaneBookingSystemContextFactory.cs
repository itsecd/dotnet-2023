using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AirplaneBookingSystem.Model;
public class AirplaneBookingSystemContextFactory : IDesignTimeDbContextFactory<AirplaneBookingSystemDbContext>
{
    public AirplaneBookingSystemDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AirplaneBookingSystemDbContext>();
        optionsBuilder.UseMySQL("AirplaneBookingSystem");
        return new AirplaneBookingSystemDbContext(optionsBuilder.Options);
    }
}