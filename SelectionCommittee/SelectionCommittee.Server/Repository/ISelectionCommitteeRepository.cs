using SelectionCommittee.Domain;

namespace SelectionCommittee.Server.Repository;

/// <summary>
/// Содержит методы для репозитория приемной комиссии.
/// </summary>
public interface ISelectionCommitteeRepository
{
    List<Enrollee> Enrollees { get; } 

    List<ExamResult> ExamResults { get; }

    List<Faculty> Faculties { get; }

    List<Specialization> Specializations { get; }
}
