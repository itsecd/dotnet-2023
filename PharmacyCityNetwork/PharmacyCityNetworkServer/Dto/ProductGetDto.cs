namespace PharmacyCityNetwork.Server.Dto;

public class ProductGetDto
{
    /// <summary>
    /// Id of product
    /// </summary>
    public int Id { get; set; } = 0;
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