namespace EnterpriseWarehouseServer.Dto;

/// <summary>
///     InvoiceContentPostDto - used to represent the invoice content object in the get-request
/// </summary>
public class InvoiceContentPostDto
{
    /// <summary>
    ///     InvoiceId - number of the invoice
    /// </summary>
    public int InvoiceId { get; set; }

    /// <summary>
    ///     ProductIN - item number of the product
    /// </summary>
    public int ProductIN { get; set; }

    /// <summary>
    ///     Quantity - quantity of goods purchased
    /// </summary>
    public int Quantity { get; set; }
}
