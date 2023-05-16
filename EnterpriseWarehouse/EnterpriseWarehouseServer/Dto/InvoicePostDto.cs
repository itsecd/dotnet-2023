namespace EnterpriseWarehouseServer.Dto;

public class InvoicePostDto
{
    /// <summary>
    ///     Id - number of the voice
    /// </summary>
    public uint Id { get; set; }

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
	public DateOnly ShipmentDate { get; set; }

    /// <summary>
    ///     Product - collection of pairs "product identifier - product quantity"
    /// </summary>
    public Dictionary<uint, uint> Products { get; set; } = new Dictionary<uint, uint>();
}