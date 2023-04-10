namespace StoreApp.Server.Dto;

public class ProductGetDto
{
    /// <summary>
    /// Product Group
    /// </summary>
    public int ProductGroup { get; set; } = -1;

    /// <summary>
    /// Product name
    /// </summary>
    public string ProductName { get; set; } = string.Empty;

    /// <summary>
    /// Product weight
    /// </summary>
    public double ProductWeight { get; set; } = 0.0;

    /// <summary>
    /// Product type (piece, weighted) piece -> true | weighted -> false
    /// </summary>
    public bool ProductType { get; set; } = false;

    /// <summary>
    /// Product price
    /// </summary>
    public double ProductPrice { get; set; } = -1.0;

    /// <summary>
    /// Product deadline date storage
    /// </summary>
    public DateTime DateStorage { get; set; } = new DateTime(1970, 1, 1);
}
