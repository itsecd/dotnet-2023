using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TransportManagment.Models;
/// <summary>
/// Pattern for creating database
/// </summary>
internal class TransportManagmentContextFactory : IDesignTimeDbContextFactory<TransportManagmentDbContext>
{
    /// <summary>
    /// Method for creating database
    /// </summary>
    /// <param name="args"></param>
    /// <returns></returns>
    public TransportManagmentDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<TransportManagmentDbContext>();
        optionsBuilder.UseMySQL("Server=127.0.0.1;Uid=root;Database=TransportManagment;Pwd=melkii11");
        return new TransportManagmentDbContext(optionsBuilder.Options);
    }
}