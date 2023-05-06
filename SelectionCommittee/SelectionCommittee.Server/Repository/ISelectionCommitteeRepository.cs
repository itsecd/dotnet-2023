using Microsoft.EntityFrameworkCore;
using SelectionCommittee.Model;

namespace SelectionCommittee.Server.Repository;

/// <summary>
/// Содержит методы для репозитория приемной комиссии.
/// </summary>
public interface ISelectionCommitteeRepository
{
    /// <summary>
    /// Список абитуриентов.
    /// </summary>
    public DbSet<EnrolleeDbModel> Enrollees { get; }

    /// <summary>
    /// Список результатов экзамена.
    /// </summary>
    public DbSet<ExamResultDbModel> ExamResults { get; }

    /// <summary>
    /// Список факультетов.
    /// </summary>
    public DbSet<FacultyDbModel> Faculties { get; }

    /// <summary>
    /// Список специальностей.
    /// </summary>
    public DbSet<SpecializationDbModel> Specializations { get; }
}
