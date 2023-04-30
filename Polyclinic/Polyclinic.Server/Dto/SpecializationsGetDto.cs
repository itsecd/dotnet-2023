namespace Polyclinic.Server.Dto;

public class SpecializationsGetDto
{
    /// <summary>
    /// specialty identifier
    /// </summary>
    public int Id { get; set; } = 0;
    /// <summary>
    /// name of specialty
    /// </summary>
    public string NameSpecialization { get; set; } = string.Empty;
}
