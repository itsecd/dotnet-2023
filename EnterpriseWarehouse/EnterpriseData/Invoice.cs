using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Enterprise.Data;

/// <summary>
///     Invoices - is a class that stores the history of shipments
/// </summary>
[Table("Invoices")]
public class Invoice
{
    /// <summary>
    ///     Id - number of the invoice
    /// </summary>
    [Key]
    [Column("invoiceId")]
    public int Id { get; set; }

    /// <summary>
    ///     NameOrganizationn - the name of the organization to which the shipment was made
    /// </summary>
    [Column("nameOrganization")]
    public string NameOrganization { get; set; } = string.Empty;

    /// <summary>
    ///     AddressOrganization - address of the organization to which the shipment was made
    /// </summary>
    [Column("addressOrganization")]
    public string AddressOrganization { get; set; } = string.Empty;

    /// <summary>
    ///     ShipmentDate - shipment date
    /// </summary>
    [Column("shipmentDate")]
    public DateTime ShipmentDate { get; set; }

    /// <summary>
    ///     InvoicesContent - invoice information
    /// </summary>
    public IList<InvoiceContent> InvoicesContent { get; } = new List<InvoiceContent>();

    public Invoice(int id, string nameOrganization, string adressOrganization, DateTime shipmentDate)
    {
        Id = id;
        NameOrganization = nameOrganization;
        AddressOrganization = adressOrganization;
        ShipmentDate = shipmentDate;
    }

    public Invoice() { }
}