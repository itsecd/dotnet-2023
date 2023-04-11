using SelectionCommittee.Domain;

namespace SelectionCommittee.Server.Controllers.Enrollees.Dto;

/// <summary>
/// Dto для Get операций сущности абитуриента.
/// </summary>
public class EnrolleeDtoGet
{
    /// <summary>
    /// Идентификатор.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Имя.
    /// </summary>
    public string FirstName { get; set; } = string.Empty;

    /// <summary>
    /// Фамилия.
    /// </summary>
    public string LastName { get; set; } = string.Empty;

    /// <summary>
    /// Отчество.
    /// </summary>
    public string Patronymic { get; set; } = string.Empty;

    /// <summary>
    /// Возраст.
    /// </summary>
    public int Age { get; set; }

    /// <summary>
    /// Дата рождения.
    /// </summary>
    public DateTime BirthDate { get; set; }

    /// <summary>
    /// Страна.
    /// </summary>
    public string Country { get; set; } = string.Empty;

    /// <summary>
    /// Город.
    /// </summary>
    public string City { get; set; } = string.Empty;

    /// <summary>
    /// Результаты экзаменов.
    /// </summary>
    public List<ExamResult>? ExamResults { get; set; }

    /// <summary>
    /// Специальности.
    /// </summary>
    public List<Specialization>? Specializations { get; set; }
}
