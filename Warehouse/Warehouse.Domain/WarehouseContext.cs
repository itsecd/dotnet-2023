using Microsoft.EntityFrameworkCore;

namespace Warehouse.Domain;
/// <summary>
/// Class represented a DbContext of Warehouse
/// </summary>
public sealed class WarehouseContext : DbContext
{
    public DbSet<Goods> Products { get; set; } = null!;
    public DbSet<Supply> Supplies { get; set; } = null!;
    public DbSet<WarehouseCells> Cells { get; set; } = null!;
    public WarehouseContext(DbContextOptions options) : base(options)
    {
        Database.EnsureCreated();
    }
}