namespace PharmacyCityNetwork.Server.Dto;

public class ProductPharmacyGetDto
{
    /// <summary>
    /// Id of productPharmacy
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Product count
    /// </summary>
    public int ProductCount { get; set; }
    /// <summary>
    /// Product cost
    /// </summary>
    public int ProductCost { get; set; }
    /// <summary>
    /// Products of product pharmacy
    /// </summary>
    public int ProductId { get; set; }
    /// <summary>
    /// Pharmacy of product pharmacy
    /// </summary>
    public int PharmacyId { get; set; }
}