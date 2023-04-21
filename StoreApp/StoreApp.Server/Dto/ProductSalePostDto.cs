namespace StoreApp.Server.Dto;

public class ProductSalePostDto
{
    /// <summary>
    /// Product ID
    /// </summary>
    public int ProductId { get; set; } = -1;
    /// <summary>
    /// Sale ID
    /// </summary>
    public int SaleId { get; set; } = -1;

    /// <summary>
    /// Product quantity
    /// </summary>
    public int Quantity { get; set; } = 0;
}
