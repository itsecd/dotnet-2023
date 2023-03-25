namespace UniversityData.Server.Dto;

public class UniversityPostDto
{
    /// <summary>
    /// Регистрационный номер
    /// </summary>
    public string Number { get; set; }
    /// <summary>
    /// Название университета
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Адрес университета
    /// </summary>
    public string Address { get; set; }
    /// <summary>
    /// ID ректора
    /// </summary>
    public int RectorId { get; set; }
    /// <summary>
    /// Собственность учреждения
    /// </summary>
    public string UniversityProperty { get; set; }
    /// <summary>
    /// Собственность здания университета
    /// </summary>
    public string ConstructionProperty { get; set; }
}
