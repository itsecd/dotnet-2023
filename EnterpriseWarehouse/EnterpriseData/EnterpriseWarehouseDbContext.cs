using Microsoft.EntityFrameworkCore;

namespace Enterprise.Data;

public class EnterpriseWarehouseDbContext : DbContext
{
    public DbSet<Product>? Products { get; set; }

    public DbSet<StorageCell>? StorageCells { get; set; }

    public DbSet<Invoice>? Invoices { get; set; }

    public DbSet<InvoiceContent>? InvoicesContent { get; set; }

    public EnterpriseWarehouseDbContext(DbContextOptions options) : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Product>()
            .HasMany(product => product.StorageCell)
            .WithOne(product => product.Product)
            .HasForeignKey(product => product.Number)
            .HasPrincipalKey(product => product.ItemNumber)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Invoice>()
            .HasMany(invoice => invoice.InvoiceContent)
            .WithOne(invoice => invoice.Invoice)
            .HasForeignKey(invoice => invoice.InvoiceId)
            .HasPrincipalKey(invoice => invoice.Id)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Product>()
            .HasMany(product => product.InvoiceContent)
            .WithOne(product => product.Product)
            .HasForeignKey(product => product.InvoiceId)
            .HasPrincipalKey(product => product.ItemNumber)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
