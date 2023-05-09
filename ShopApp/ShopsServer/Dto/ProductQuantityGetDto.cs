namespace Shops.Server.Dto;
/// <summary>
/// Class ProductQuantityGetDto is used to make HTTP GET request.
/// </summary>
public class ProductQuantityGetDto
{
    /// <summary>
    /// Id is used to store the ID.
    /// </summary>
    public int Id { get; set; } = 0;
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
