namespace ShopsServer.Dto;
/// <summary>
/// Class PurchaseRecordPostDto is used to make HTTP POST request.
/// </summary>
public class PurchaseRecordPostDto
{
    /// <summary>
    /// Were bought
    /// </summary>
    public int ShopId { get; set; }
    /// <summary>
    /// Who bought (id)
    /// </summary>
    public int CustomerId { get; set; }
    /// <summary>
    /// What bought (barcode)
    /// </summary>
    public int ProductId { get; set; }
    /// <summary>
    /// What bought (barcode)
    /// </summary>
    public double Quantity { get; set; } = 0.0;
    /// <summary>
    /// When bought
    /// </summary>
    public DateTime DateSale { get; set; }

}
