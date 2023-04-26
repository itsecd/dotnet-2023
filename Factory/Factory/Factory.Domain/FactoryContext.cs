using Microsoft.EntityFrameworkCore;

namespace Factory.Domain;

/// <summary>
/// Class FactoryContext connecting with database
/// </summary>
public sealed class FactoryContext : DbContext
{
    /// <summary>
    /// Types of Industry collection
    /// </summary>
    public DbSet<TypeIndustry> IndustryTypes { get; set; } = null!;

    /// <summary>
    /// Ownership Forms collection
    /// </summary>
    public DbSet<OwnershipForm> OwnershipForms { get; set; } = null!;

    /// <summary>
    /// Enterprises collection
    /// </summary>
    public DbSet<Enterprise> Enterprises { get; set; } = null!;

    /// <summary>
    /// Suppliers collection
    /// </summary>
    public DbSet<Supplier> Suppliers { get; set; } = null!;

    /// <summary>
    /// Supplies collection
    /// </summary>
    public DbSet<Supply> Supplies { get; set; } = null!;

    /// <summary>
    /// Database creating
    /// </summary>
    /// <param name="options"></param>
    public FactoryContext(DbContextOptions options) : base(options)
    {
        Database.EnsureCreated();
    }

    /// <summary>
    /// Values to the database
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Supply>().HasData(
            new Supply(1, 1, 1, "20.01.2023", 3),
            new Supply(2, 1, 2, "31.10.2022", 5),
            new Supply(3, 3, 3, "14.08.2022", 1),
            new Supply(4, 4, 4, "05.02.2023", 10),
            new Supply(5, 2, 5, "27.02.2023", 6),
            new Supply(6, 5, 5, "13.01.2023", 2),
            new Supply(7, 4, 3, "04.01.2023", 12),
            new Supply(8, 2, 2, "09.12.2022", 4)
            );

        modelBuilder.Entity<Enterprise>().HasData(
            new Enterprise(1, "1036300446093", 6, "СТАН", "ул.22 партъезда д.7а", "88469926984", 1, 100, 1000),
            new Enterprise(2, "1156313028981", 6, "ЗГМ", "ул.22 партъезда д.10а", "88462295931", 2, 150, 1500),
            new Enterprise(3, "1116318009510", 4, "ВЗМК", "ул.Балаковская д.6а", "884692007711", 2, 200, 2000),
            new Enterprise(4, "1026300767899", 2, "АВИАКОР", "ул.Земеца д.32", "88463720888", 3, 250, 2500),
            new Enterprise(5, "1026301697487", 6, "ЭКРАН", "ул.Кирова д.24", "88469983785", 4, 130, 1300)
            );

        modelBuilder.Entity<TypeIndustry>().HasData(
            new TypeIndustry(1, "Cельское хозяйство"),
            new TypeIndustry(2, "Транспорт"),
            new TypeIndustry(3, "Легкая промышленность"),
            new TypeIndustry(4, "Тяжелая промышленность"),
            new TypeIndustry(5, "Строительство"),
            new TypeIndustry(6, "Материально - техническое снабжение")
            );

        modelBuilder.Entity<OwnershipForm>().HasData(
            new OwnershipForm(1, "ЗАО"),
            new OwnershipForm(2, "ООО"),
            new OwnershipForm(3, "АО"),
            new OwnershipForm(4, "ОАО")
            );
        modelBuilder.Entity<Supplier>().HasData(
            new Supplier(1, "Артур Пирожков", "ул. Зацепильная д.42", "89375550203"),
            new Supplier(2, "Чендлер Бинг", "ул. Центральная д.1", "89370101010"),
            new Supplier(3, "Барни Стинсон", "ул. Приоденься д.50", "89376431289"),
            new Supplier(4, "Джон Сноу", "ул. Таргариенская д.35", "89372229978"),
            new Supplier(5, "Райан Гослинг", "ул. Лалаленд д.14", "89371234567")
            );
    }
}
