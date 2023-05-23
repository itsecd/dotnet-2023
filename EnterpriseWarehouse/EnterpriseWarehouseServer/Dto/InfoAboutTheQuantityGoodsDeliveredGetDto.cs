namespace EnterpriseWarehouseServer.Dto;

/// <summary>
///     InfoAboutTheQuantityGoodsDeliveredGetDto - used to represent the Invoices and Product objects in the get-request
/// </summary>
public class InfoAboutTheQuantityGoodsDeliveredGetDto
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
    ///     ItemNumber - unique identifier of the product
    /// </summary>
    public int ItemNumber { get; set; }

    /// <summary>
    ///     Title - product name
    /// </summary>
	public string Title { get; set; } = string.Empty;

    /// <summary>
    ///     Quantity - total amount of goods delivered
    /// </summary>
	public long Quantity { get; set; }
}
