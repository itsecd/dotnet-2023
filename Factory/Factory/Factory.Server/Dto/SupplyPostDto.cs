namespace Factory.Server.Dto;

/// <summary>
/// Class describing supplying
/// </summary>
public class SupplyPostDto
{
    /// <summary>
    /// Enterprise identifier
    /// </summary>
    public int EnterpriseID { get; set; } = 0;

    /// <summary>
    /// Supplier identifier
    /// </summary>
    public int SupplierID { get; set; } = 0;

    /// <summary>
    /// Date
    /// </summary>
    public DateTime Date { get; set; } = new DateTime(1970, 1, 1);

    /// <summary>
    /// Goods count
    /// </summary>
    public int Quantity { get; set; } = 0;
}
