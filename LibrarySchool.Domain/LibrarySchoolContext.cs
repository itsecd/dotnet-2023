using Microsoft.EntityFrameworkCore;

namespace LibrarySchool.Domain;
public sealed class LibrarySchoolContext : DbContext
{
    public DbSet<Student> Students { get; set; } = null!;
    public DbSet<Mark> Marks { get; set; } = null!;
    public DbSet<Subject> Subjects { get; set; } = null!;
    public DbSet<ClassType> ClassTypes { get; set; } = null!;
    private SeedDataGenerator _seedDataGenerator = null!;

    public LibrarySchoolContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        _seedDataGenerator = new SeedDataGenerator();

        modelBuilder.Entity<Subject>().HasData(_seedDataGenerator.Subjects);
        modelBuilder.Entity<ClassType>().HasData(_seedDataGenerator.ClassTypes);
        modelBuilder.Entity<Student>().HasData(_seedDataGenerator.Students);
        modelBuilder.Entity<Mark>().HasData(_seedDataGenerator.Marks);

        modelBuilder.Entity<Student>()
                    .HasOne(student => student.ClassType)
                    .WithMany(student => student.Students)
                    .OnDelete(DeleteBehavior.Cascade);
        
        modelBuilder.Entity<Student>()
                    .HasMany(student => student.Marks)
                    .WithOne(mark => mark.Student)
                    .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Mark>()
                    .HasOne(mark => mark.Subject)
                    .WithMany(subject => subject.Marks)
                    .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Student>().HasKey(student => student.StudentId);
        modelBuilder.Entity<ClassType>().HasKey(classType => classType.ClassId);
        modelBuilder.Entity<Mark>().HasKey(mark => mark.MarkId);
        modelBuilder.Entity<Subject>().HasKey(subject => subject.SubjectId);
    }
}

