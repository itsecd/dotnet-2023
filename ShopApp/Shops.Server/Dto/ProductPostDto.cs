namespace Shops.Server.Dto;

public class ProductPostDto
{
    public string Barcode { get; set; } = string.Empty;
    /// <summary>
    /// Product name
    /// </summary>
    public string Name { get; set; } = string.Empty;
    /// <summary>
    /// Product group code 
    /// </summary>
    public int ProductGroupCode { get; set; } = 0;
    /// <summary>
    /// Product weight
    /// </summary>
    public double Weight { get; set; } = 0.0;
    /// <summary>
    /// Product type (piece or bulk)
    /// </summary>
    public string ProductType { get; set; } = string.Empty;
    /// <summary>
    /// Product price
    /// </summary>
    public double Price { get; set; } = 0.0;
    /// <summary>
    /// Storage limit date
    /// </summary>
    public DateTime StorageLimitDate { get; set; } = new DateTime();
}
