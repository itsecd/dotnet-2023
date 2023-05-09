namespace SelectionCommittee.Server.Controllers.Enrollees.Dto;

/// <summary>
/// Dto для Post и Put операций сущности абитуриента.
/// </summary>
public class EnrolleeDtoPostOrPut
{
    /// <summary>
    /// Имя.
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// Фамилия.
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// Отчество.
    /// </summary>
    public string Patronymic { get; set; }

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
    public string Country { get; set; }

    /// <summary>
    /// Город.
    /// </summary>
    public string City { get; set; }

    /// <summary>
    /// Идентификатор специальности.
    /// </summary>
    public int SpecializationId { get; set; }
}
