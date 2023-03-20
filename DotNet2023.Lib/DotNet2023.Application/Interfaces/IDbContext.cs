
using DotNet2023.Domain.InstituteDocumentation;
using DotNet2023.Domain.InstitutionStructure;
using DotNet2023.Domain.Organization;
using DotNet2023.Domain.Person;
using Microsoft.EntityFrameworkCore;

namespace DotNet2023.Application.Interfaces;
public interface IDbContext
{
    public DbSet<Student> Students { get; set; }
    public DbSet<EducationWorker> EducationWorker { get; set; }

    public DbSet<HigherEducationInstitution> Institutes { get; set; }

    public DbSet<Faculty> Faculties { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<GroupOfStudents> GroupOfStudents { get; set; }

    public DbSet<InstituteSpeciality> InstituteSpecialties { get; set; }
    public DbSet<Speciality> Specialties { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
