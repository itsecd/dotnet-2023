namespace EnterpriseWarehouseServer.Dto;

/// <summary>
///     InvoicePostDto - used to present Invoices object data in a post-query
/// </summary>
public class InvoicePostDto
{
    /// <summary>
    ///     Id - number of the voice
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    ///     NameOrganizationn - the name of the organization to which the shipment was made
    /// </summary>
	public string NameOrganization { get; set; } = string.Empty;

    /// <summary>
    ///     AdressOrganization - address of the organization to which the shipment was made
    /// </summary>
	public string AdressOrganization { get; set; } = string.Empty;

    /// <summary>
    ///     ShipmentDate - shipment date
    /// </summary>
	public string ShipmentDate { get; set; } = string.Empty;

    /// <summary>
    ///     Product - collection of pairs "product identifier - product quantity"
    /// </summary>
    public Dictionary<int, int> Products { get; set; } = new Dictionary<int, int>();
}