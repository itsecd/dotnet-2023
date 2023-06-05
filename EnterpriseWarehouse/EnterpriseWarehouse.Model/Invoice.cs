using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnterpriseWarehouse.Model;

/// <summary>
///     Invoices - is a class that stores the history of shipments
/// </summary>
[Table("invoices")]
public class Invoice
{
    /// <summary>
    ///     Id - number of the invoice
    /// </summary>
    [Key]
    [Column("invoice_id")]
    public int Id { get; set; }

    /// <summary>
    ///     NameOrganizationn - the name of the organization to which the shipment was made
    /// </summary>
    [Column("name_organization")]
    public string NameOrganization { get; set; } = string.Empty;

    /// <summary>
    ///     AddressOrganization - address of the organization to which the shipment was made
    /// </summary>
    [Column("address_organization")]
    public string AddressOrganization { get; set; } = string.Empty;

    /// <summary>
    ///     ShipmentDate - shipment date
    /// </summary>
    [Column("shipment_date")]
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