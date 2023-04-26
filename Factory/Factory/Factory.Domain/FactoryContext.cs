using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Domain;

public sealed class FactoryContext : DbContext
{
    public DbSet<TypeIndustry> IndustryTypes { get; set; } = null!;
    public DbSet<OwnershipForm> OwnershipForms { get; set; } = null!;
    public DbSet<Enterprise> Enterprises { get; set; } = null!;
    public DbSet<Supplier> Suppliers { get; set; } = null!;
    public DbSet<Supply> Supplies { get; set; } = null!;
    /// <summary>
    /// Database creating
    /// </summary>
    /// <param name="options"></param>
    public FactoryContext(DbContextOptions options) : base(options)
    {
        Database.EnsureCreated(); 
    }
}
