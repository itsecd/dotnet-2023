namespace PoliclinicServer.Dto;
/// <summary>
/// SpecializationDto is for HTTP GET requests
/// </summary>
public class SpecializationDto
{
    /// <summary>
    /// Id is an int typed value for storing Id of the specialization
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// NameSpecialization is a string typed value representing the name of specialization
    /// </summary>
    public string NameSpecialization { get; set; } = string.Empty;
}
