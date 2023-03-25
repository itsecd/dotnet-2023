namespace UniversityData.Server.Dto;

public class UniversityGetDto
{
    /// <summary>
    /// ID
    /// </summary>
    public int Id { get; set; }
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
    /// Сведения о ректоре 
    /// </summary>
    public string UniversityProperty { get; set; }
    /// <summary>
    /// Собственность здания университета
    /// </summary>
    public string ConstructionProperty { get; set; }
    /// <summary>
    /// Факультеты университета
    /// </summary>
}
