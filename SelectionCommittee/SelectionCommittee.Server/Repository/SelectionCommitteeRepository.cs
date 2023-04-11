namespace SelectionCommittee.Server.Repository;

using SelectionCommittee.Domain;

/// <summary>
/// Работа со списками сущностей приемной комиссии.
/// </summary>
public class SelectionCommitteeRepository : ISelectionCommitteeRepository
{
    /// <summary>
    /// Список абитуриентов.
    /// </summary>
    private readonly List<Enrollee> _enrollees;

    /// <summary>
    /// Список результатов экзамена.
    /// </summary>
    private readonly List<ExamResult> _examResults;

    /// <summary>
    /// Список факультетов.
    /// </summary>
    private readonly List<Faculty> _faculties;

    /// <summary>
    /// Список специальностей.
    /// </summary>
    private readonly List<Specialization> _specializations;

    /// <summary>
    /// Создание репозитория.
    /// </summary>
    public SelectionCommitteeRepository()
    {
        _enrollees = new List<Enrollee>();
        _examResults = new List<ExamResult>();
        _faculties = new List<Faculty>();
        _specializations = new List<Specialization>();
    }

    /// <summary>
    /// Получение списка абитуриентов.
    /// </summary>
    public List<Enrollee> Enrollees => _enrollees;

    /// <summary>
    /// Получение списка результатов экзамена.
    /// </summary>
    public List<ExamResult> ExamResults => _examResults;

    /// <summary>
    /// Получение списка факультетов.
    /// </summary>
    public List<Faculty> Faculties => _faculties;

    /// <summary>
    /// Получение списка специальностей.
    /// </summary>
    public List<Specialization> Specializations => _specializations;
}
