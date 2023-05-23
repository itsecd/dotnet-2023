namespace EnterpriseWarehouseServer.Dto;

/// <summary>
///     InfoOfAllInvoiceGetDto - used to represent the all Invoices object in the get-request
/// </summary>
public class InfoOfAllInvoiceGetDto
{
    /// <summary>
    ///     NameOrganizationn - the name of the organization to which the shipment was made
    /// </summary>
    public string NameOrganization { get; set; } = string.Empty;

    /// <summary>
    ///     AdressOrganization - address of the organization to which the shipment was made
    /// </summary>
	public string AdressOrganization { get; set; } = string.Empty;

    /// <summary>
    ///     Quantity - quantity of goods stored in the warehouse
    /// </summary>
    public long Quantity { get; set; }
}
