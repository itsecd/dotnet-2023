namespace EnterpriseWarehouse.Server.Dto;

/// <summary>
///     InvoiceGetDto - used to represent the Invoices object in the get-request
/// </summary>
public class InvoiceGetDto
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
	public string AddressOrganization { get; set; } = string.Empty;

    /// <summary>
    ///     ShipmentDate - shipment date
    /// </summary>
	public string ShipmentDate { get; set; }

    /// <summary>
    ///     Product - collection of pairs "product identifier - product quantity"
    /// </summary>
    public Dictionary<int, int> Products { get; set; } = new Dictionary<int, int>();
}