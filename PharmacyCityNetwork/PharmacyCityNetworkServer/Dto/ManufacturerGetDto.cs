namespace PharmacyCityNetwork.Server.Dto;

public class ManufacturerGetDto
{
    /// <summary>
    /// Id of manufacturer
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Manufacturer name
    /// </summary>
    public string ManufacturerName { get; set; } = string.Empty;
}
