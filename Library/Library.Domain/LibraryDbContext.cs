using Microsoft.EntityFrameworkCore;

namespace Library.Domain;
/// <summary>
/// LibraryDbContext is used to create database
/// </summary>
public class LibraryDbContext : DbContext
{
    /// <summary>
    /// Books is used to store collection of books
    /// </summary>
    public DbSet<Book>? Books { get; set; } = null!;
    /// <summary>
    /// Cards is used to store collection of cards
    /// </summary>
    public DbSet<Card>? Cards { get; set; } = null!;
    /// <summary>
    /// Departments is used to store collection of departments
    /// </summary>
    public DbSet<Department>? Departments { get; set; } = null!;
    /// <summary>
    /// Readers is used to store collection of readers
    /// </summary>
    public DbSet<Reader>? Readers { get; set; } = null!;
    /// <summary>
    /// TypesDepartment is used to store collection of types departments
    /// </summary>
    public DbSet<TypeDepartment>? TypesDepartment { get; set; } = null!;
    /// <summary>
    /// TypesEdition is used to store collection of types editions
    /// </summary>
    public DbSet<TypeEdition>? TypesEdition { get; set; } = null!;
    /// <summary>
    /// Library's DbContext constructor
    /// </summary>
    /// <param name="options"></param>
    public LibraryDbContext(DbContextOptions options) : base(options)
    {
        Database.EnsureCreated();
    }
    /// <summary>
    /// Method for insert data into database
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Card>().HasData(new List<Card>
        {
            new() { Id = 1, DateOfIssue = new DateTime(2022, 12, 29), DateOfReturn = new DateTime(2023, 1, 28), DayCount = 31, ReaderId = 1, BookId = 1 },
            new() { Id = 2, DateOfIssue = new DateTime(2022, 12, 29), DateOfReturn = new DateTime(2023, 1, 28), DayCount = 31, ReaderId = 1, BookId = 4 },
            new() { Id = 3, DateOfIssue = new DateTime(2022, 12, 29), DateOfReturn = new DateTime(2023, 1, 28), DayCount = 31, ReaderId = 2, BookId = 4 },
            new() { Id = 4, DateOfIssue = new DateTime(2022, 12, 29), DateOfReturn = new DateTime(2023, 1, 28), DayCount = 31, ReaderId = 2, BookId = 2 },
            new() { Id = 5, DateOfIssue = new DateTime(2022, 12, 29), DateOfReturn = new DateTime(2023, 1, 31), DayCount = 31, ReaderId = 2, BookId = 3 },
            new() { Id = 6, DateOfIssue = new DateTime(2022, 12, 30), DateOfReturn = new DateTime(2023, 2, 14), DayCount = 30, ReaderId = 3, BookId = 3 },
            new() { Id = 7, DateOfIssue = new DateTime(2022, 12, 30), DateOfReturn = new DateTime(2023, 2, 14), DayCount = 30, ReaderId = 4, BookId = 2 },
            new() { Id = 8, DateOfIssue = new DateTime(2023, 2, 14), DateOfReturn = new DateTime(2023, 2, 28), DayCount = 21, ReaderId = 5, BookId = 1 }
        });

        modelBuilder.Entity<Department>().HasData(new List<Department>
        {
            new() { Id = 1, TypeDepartmentId = 2, BookId = 1, Count = 40 },
            new() { Id = 2, TypeDepartmentId = 2, BookId = 2, Count = 35 },
            new() { Id = 3, TypeDepartmentId = 2, BookId = 3, Count = 33 },
            new() { Id = 4, TypeDepartmentId = 1, BookId = 4, Count = 15 },
            new() { Id = 5, TypeDepartmentId = 2, BookId = 4, Count = 20 }
        });

        modelBuilder.Entity<TypeDepartment>().HasData(new List<TypeDepartment>
        {
            new() { Id = 1, Name = "Scientific" },
            new() { Id = 2, Name = "Study" }
        });

        modelBuilder.Entity<TypeEdition>().HasData(new List<TypeEdition>
        {
            new() { Id = 1, Name = "Tutorial" },
            new() { Id = 2, Name = "Monograph" },
            new() { Id = 3, Name = "Methodological guidelines" }
        });

        modelBuilder.Entity<Book>().HasData(new List<Book>
        {
            new() { Id = 1, Cipher = "5698/197b", Author = "Vasilev A.V.", Name = "Boolean algebra tutorial", PlaceEdition = "Kuibyshev", YearEdition = 1989, TypeEditionId = 3 },
            new() { Id = 2, Cipher = "5696/197b", Author = "Vasilev A.V.", Name = "Mathematical analysis manual", PlaceEdition = "Kuibyshev", YearEdition = 1988, TypeEditionId = 3 },
            new() { Id = 3, Cipher = "5832/198c", Author = "Merkulov D.A.", Name = "Computer science and computer engineering", PlaceEdition = "Samara", YearEdition = 2005, TypeEditionId = 1 },
            new() { Id = 4, Cipher = "7896/215a", Author = "Andropov I.S.", Name = "Nanoelectronics and medicine", PlaceEdition = "Samara", YearEdition = 2017, TypeEditionId = 2 }
        });

        modelBuilder.Entity<Reader>().HasData(new List<Reader>
        {
            new() { Id = 1, FullName = "Chernyi Vladislav Andreevich", Address = "Moscow highway 34", Phone = "89277668974", RegistrationDate = new DateTime(2022, 12, 25) },
            new() { Id = 2, FullName = "Kurakin Artem Sergeevich", Address = "Moscow highway 34", Phone = "89277668974", RegistrationDate = new DateTime(2022, 12, 25) },
            new() { Id = 3, FullName = "Arapenkov Stepan Vladimirovich", Address = "Moscow highway 34", Phone = "89277352678", RegistrationDate = new DateTime(2022, 12, 25) },
            new() { Id = 4, FullName = "Danilov Artem Andreevich", Address = "Moscow highway 34", Phone = "89277114578", RegistrationDate = new DateTime(2022, 12, 26) },
            new() { Id = 5, FullName = "Denisov Stepan Vladimirovich", Address = "Moscow highway 34", Phone = "89277550173", RegistrationDate = new DateTime(2022, 12, 27) }
        });
    }
}