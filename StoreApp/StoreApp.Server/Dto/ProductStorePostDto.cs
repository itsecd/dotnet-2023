namespace StoreApp.Server.Dto;

public class ProductStorePostDto
{
    /// <summary>
    /// Product ID
    /// </summary>
    public int ProductId { get; set; } = -1;
    /// <summary>
    /// Store ID
    /// </summary>
    public int StoreId { get; set; } = -1;

    /// <summary>
    /// Product quantity
    /// </summary>
    public int Quantity { get; set; } = 0;
}
