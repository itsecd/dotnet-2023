using dotnet_2023.DataBase.EntityTypeConfigurations.InsituteStructureConfiguration;
using dotnet_2023.DataBase.EntityTypeConfigurations.InstituteDocumentationConfiguration;
using dotnet_2023.DataBase.EntityTypeConfigurations.OrganizationConfiguration;
using dotnet_2023.DataBase.EntityTypeConfigurations.PersonConfiguration;
using dotnet_2023.DataModel.InstituteDocumentation;
using dotnet_2023.DataModel.InstitutionStructure;
using dotnet_2023.DataModel.Organization;
using dotnet_2023.DataModel.Person;
using Microsoft.EntityFrameworkCore;

namespace dotnet_2023.DataBase.DBContext;

public class DataBaseContext : DbContext
{
    public DbSet<Student> Students { get; set; }
    public DbSet<EducationWorker> EducationWorker { get; set; }

    public DbSet<HigherEducationInstitution> Institutes { get; set; }

    public DbSet<Faculty> Faculties { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<GroupOfStudents> GroupOfStudents { get; set; }

    public DbSet<InstituteSpeciality> InstituteSpecialties { get; set; }
    public DbSet<Speciality> Specialties { get; set; }

    public DataBaseContext(DbContextOptions<DataBaseContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(StudentConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EducationWorkerConfiguration).Assembly);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(HigherEducationInstitutionConfiguration).Assembly);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(FacultyConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DepartmentConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(GroupOfStudentsConfiguration).Assembly);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(InstituteSpecialityConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SpecialityConfiguration).Assembly);
    }
}
