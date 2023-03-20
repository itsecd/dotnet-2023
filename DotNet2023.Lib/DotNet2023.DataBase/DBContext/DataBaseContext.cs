using DotNet2023.DataBase.EntityTypeConfigurations.InsituteStructureConfiguration;
using DotNet2023.DataBase.EntityTypeConfigurations.InstituteDocumentationConfiguration;
using DotNet2023.DataBase.EntityTypeConfigurations.OrganizationConfiguration;
using DotNet2023.DataBase.EntityTypeConfigurations.PersonConfiguration;
using DotNet2023.Domain.InstituteDocumentation;
using DotNet2023.Domain.InstitutionStructure;
using DotNet2023.Domain.Organization;
using DotNet2023.Domain.Person;
using Microsoft.EntityFrameworkCore;

namespace DotNet2023.DataBase.DBContext;

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

    public DataBaseContext() : base() { }
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
