namespace Warehouse.Server.Dto;

/// <summary>
///     Class GoodsPostDto is used to store info about the products
/// </summary>
public class ProductsPostDto
{
    /// <summary>  
    ///     Id - shows the product's id
    /// </summary>  
    public int Id { set; get; }
    /// <summary>
    ///     Quantity - shows amount of product
    /// </summary>  
    public int Quantity { set; get; }
    /// <summary>
    ///     Name - a string that stores product name 
    /// </summary>
    public string Name { set; get; } = string.Empty;
}