using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Enterprise.Data;

/// <summary>
///     Invoice - is a class that stores the history of shipments
/// </summary>
public class Invoice
{
    /// <summary>
    ///     Id - number of the invoice
    /// </summary>
    [Key]
    [Column("id")]
    public uint Id { get; set; }

    /// <summary>
    ///     NameOrganizationn - the name of the organization to which the shipment was made
    /// </summary>
    [Column("nameOrganization")]
    public string NameOrganization { get; set; } = string.Empty;

    /// <summary>
    ///     AdressOrganization - address of the organization to which the shipment was made
    /// </summary>
    [Column("addressOrganization")]
    public string AdressOrganization { get; set; } = string.Empty;

    /// <summary>
    ///     ShipmentDate - shipment date
    /// </summary>
    [Column("shipmentDate")]
    public DateTime ShipmentDate { get; set; }

    /// <summary>
    ///     InvoiceContentid - invoice information number
    /// </summary>
    public List<InvoiceContent> InvoiceContent { get; set; } = new List<InvoiceContent>();

    public Invoice(uint id, string nameOrganization, string adressOrganization, DateTime shipmentDate)
    {
        Id = id;
        NameOrganization = nameOrganization;
        AdressOrganization = adressOrganization;
        ShipmentDate = shipmentDate;
    }
}