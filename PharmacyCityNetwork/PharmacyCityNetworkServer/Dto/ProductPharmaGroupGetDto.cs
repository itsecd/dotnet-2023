namespace PharmacyCityNetwork.Server.Dto;

public class ProductPharmaGroupGetDto
{
    /// <summary>
    /// Id of product pharma group
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Pharma group
    /// </summary>
    public int PharmaGroupId { get; set; }
    /// <summary>
    /// Product of pharma group
    /// </summary>
    public int ProductId { get; set; }
}
