namespace Warehouse.Server.Dto;

/// <summary>
///     Class GoodsPostDto is used to store info about the products
/// </summary>
public class GoodsPostDto
{
    /// <summary>  
    ///     Id - shows the product's id
    /// </summary>  
    public int Id { set; get; }
    /// <summary>
    ///     ProductCount - shows amount of product
    /// </summary>  
    public int ProductCount { set; get; }
    /// <summary>
    ///     Name - a string that stores product name 
    /// </summary>
    public string Name { set; get; } = string.Empty;
}