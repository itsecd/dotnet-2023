namespace SchoolServer.Dto;

/// <summary>
/// Subject class для метода Get
/// </summary>
public class SubjectGetDto
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Наименование предмета
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Год обучения
    /// </summary>
    public int Year { get; set; }
}
