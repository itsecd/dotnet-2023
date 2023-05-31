namespace SchoolServer.Dto;

/// <summary>
/// Dto для метода Post класса Student  
/// </summary>
public class StudentPostDto
{
    /// <summary>	
    /// Имя
    /// </summary>	
    public string FirstName { get; set; } = string.Empty;

    /// <summary>	
    /// Фамилия	
    /// </summary>	
    public string LastName { get; set; } = string.Empty;

    /// <summary>	
    /// Отчество
    /// </summary>	
    public string Patronymic { get; set; } = string.Empty;

    /// <summary>
    /// Паспортные данные
    /// </summary>
    public string Passport { get; set; } = string.Empty;

    /// <summary>
    /// Класс студента
    /// </summary>
    public int ClassId { get; set; }

    /// <summary>
    /// Дата рождения
    /// </summary>
    public DateTime BirthDate { get; set; }
}
