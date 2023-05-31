namespace SchoolServer.Dto;

/// <summary>
/// Dto для метода Post класса Subject  
/// </summary>
public class SubjectPostDto
{
    /// <summary>
    /// Наименование предмета
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Год обучения
    /// </summary>
    public int Year { get; set; }
}
