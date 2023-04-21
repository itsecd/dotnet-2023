namespace StoreApp.Server.Dto;

public class ProductSaleGetDto
{
    /// <summary>
    /// CustomerId
    /// </summary>
    public int Id { get; set; } = -1;
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
