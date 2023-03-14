namespace EnterpriseData;

/// <summary>
///     Invoice - is a class that stores the history of shipments
/// </summary>
public class Invoice
{
    /// <summary>
    ///     Id - number of the voice
    /// </summary>
    public uint Id { get; set; }

    /// <summary>
    ///     ItemNumberProduct - unique identifier of the product
    /// </summary>
    public uint ItemNumberProduct { get; set; }

    /// <summary>
    ///     NameOrganizationn - the name of the organization to which the shipment was made
    /// </summary>
	public string NameOrganizationn { get; set; } = string.Empty;

    /// <summary>
    ///     AdressOrganization - address of the organization to which the shipment was made
    /// </summary>
	public string AdressOrganization { get; set; } = string.Empty;

    /// <summary>
    ///     ShipmentDate - shipment date
    /// </summary>
	public DateOnly ShipmentDate { get; set; } = DateOnly.MinValue;

    /// <summary>
    ///     ShipmentDate - quantity shipped
    /// </summary>
    public uint Quntity { get; set; }

	public Invoice(uint id, uint itemNumberProduct, string nameOrganizationn, string adressOrganization, DateOnly shipmentDate, uint quntity)
    {
        Id = id;
        ItemNumberProduct = itemNumberProduct;
        NameOrganizationn = nameOrganizationn;
        AdressOrganization = adressOrganization;
        ShipmentDate = shipmentDate;
        Quntity = quntity;
    }
}