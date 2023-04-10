namespace SchoolServer.Dto;

public class ClassGetDto
{
    /// <summary>
    /// Идентификатор класса
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Номер класса
    /// </summary>
    public int Number { get; set; }

    /// <summary>
    /// Литера класса
    /// </summary>
    public char Letter { get; set; }
}
