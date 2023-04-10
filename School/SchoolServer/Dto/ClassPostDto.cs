namespace SchoolServer.Dto;

/// <summary>
/// Класс - класс описывающий класс ученика
/// </summary>
public class ClassPostDto
{
    /// <summary>
    /// Номер класса
    /// </summary>
    public int Number { get; set; }

    /// <summary>
    /// Литера класса
    /// </summary>
    public char Letter { get; set; }
}
