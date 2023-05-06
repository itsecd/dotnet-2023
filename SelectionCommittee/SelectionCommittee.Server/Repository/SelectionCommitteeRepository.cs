namespace SelectionCommittee.Server.Repository;

using Microsoft.EntityFrameworkCore;
using SelectionCommittee.Domain;
using SelectionCommittee.Model;
using SocialNetwork.Data;

/// <summary>
/// Работа со списками сущностей приемной комиссии.
/// </summary>
public class SelectionCommitteeRepository : ISelectionCommitteeRepository
{
    /// <summary>
    /// Контекст приемной комиссии.
    /// </summary>
    private readonly SelectionCommitteeContext _context;

    public SelectionCommitteeRepository(SelectionCommitteeContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Получение списка абитуриентов.
    /// </summary>
    public DbSet<EnrolleeDbModel> Enrollees =>  _context.Enrollees;

    /// <summary>
    /// Получение списка результатов экзамена.
    /// </summary>
    public DbSet<ExamResultDbModel> ExamResults => _context.ExamResults;

    /// <summary>
    /// Получение списка факультетов.
    /// </summary>
    public DbSet<FacultyDbModel> Faculties => _context.Faculties;

    /// <summary>
    /// Получение списка специальностей.
    /// </summary>
    public DbSet<SpecializationDbModel> Specializations => _context.Specializations;
}
