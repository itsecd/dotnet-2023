namespace PharmacyCityNetwork.Server.Dto;

public class PharmacyPostDto
{
    /// <summary>
    /// Pharmacy name
    /// </summary>
    public string PharmacyName { get; set; } = string.Empty;
    /// <summary>
    /// Pharmacy phone
    /// </summary>
    public string PharmacyPhone { get; set; } = string.Empty;
    /// <summary>
    /// Pharmacy address
    /// </summary>
    public string PharmacyAddress { get; set; } = string.Empty;
    /// <summary>
    /// Pharmacy director
    /// </summary>
    public string PharmacyDirector { get; set; } = string.Empty;
}
