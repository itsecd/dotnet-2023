namespace PharmacyCityNetwork.Server.Dto;

public class ProductPharmacyGetDto
{
    /// <summary>
    /// Product count
    /// </summary>
    public int ProductCount { get; set; } = 0;
    /// <summary>
    /// Product cost
    /// </summary>
    public int ProductCost { get; set; } = 0;
    /// <summary>
    /// Products of product pharmacy
    /// </summary>
    public int ProductId { get; set; }
    /// <summary>
    /// Pharmacy of product pharmacy
    /// </summary>
    public int PharmacyId { get; set; }
}