using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TaxiDepo.Model;

/// <summary>
/// TaxiDepoContextFactory class
/// </summary>
public class TaxiDepoContextFactory : IDesignTimeDbContextFactory<TaxiDepoDbContext>
{
    /// <summary>
    /// Create DbContext
    /// </summary>
    /// <param name="args">Pargs</param>
    /// <returns>new TaxiDepoDbContext</returns>
    /// <exception cref="NotImplementedException">Exception</exception>
    public TaxiDepoDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<TaxiDepoDbContext>();
        return new TaxiDepoDbContext(optionsBuilder.Options);
    }
}