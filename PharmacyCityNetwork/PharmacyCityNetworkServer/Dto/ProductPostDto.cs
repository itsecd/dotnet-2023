namespace PharmacyCityNetwork.Server.Dto;

public class ProductPostDto
{
    /// <summary>
    /// Product name
    /// </summary>
    public string ProductName { get; set; } = string.Empty;
    /// <summary>
    /// Product group
    /// </summary>
    public int GroupId { get; set; }
    /// <summary>
    /// Product manufacturer
    /// </summary>
    public int ManufacturerId { get; set; }
}