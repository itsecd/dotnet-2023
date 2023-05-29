namespace ShopsServer.Dto;
/// <summary>
/// Class ProductQuantityPostDto is used to make HTTP POST request.
/// </summary>
public class ProductQuantityPostDto
{
    /// <summary>
    /// Product barcode
    /// </summary>
    public int ProductId { get; set; } = 0;
    /// <summary>
    /// Shop id
    /// </summary>
    public int ShopId { get; set; } = 0;
    /// <summary>
    /// Product quantity
    /// </summary>
    public double Quantity { get; set; } = 0.0;
}
