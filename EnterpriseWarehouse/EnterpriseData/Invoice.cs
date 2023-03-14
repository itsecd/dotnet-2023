namespace Enterprise.Data;

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
	public DateOnly ShipmentDate { get; set; }

    /// <summary>
    ///     Product - collection of pairs "product identifier - product quantity"
    /// </summary>
    public Dictionary<uint, uint> Products { get; set; } = new Dictionary<uint, uint>();

    public Invoice(uint id, string nameOrganizationn, string adressOrganization, DateOnly shipmentDate, Dictionary<uint, uint> products)
    {
        Id = id;
        NameOrganizationn = nameOrganizationn;
        AdressOrganization = adressOrganization;
        ShipmentDate = shipmentDate;
        Products = products;
    }
}