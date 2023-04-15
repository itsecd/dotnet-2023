namespace Warehouse.Server.Dto;

/// <summary>
///     Class GoodsGetDto is used to store info about the products
/// </summary>
public class GoodsGetDto
{
    /// <summary>  
    ///     Id - shows the product's id
    /// </summary>  
    public int Id { set; get; } = 0;
    /// <summary>
    ///     ProductCount - shows amount of product
    /// </summary>  
    public int ProductCount { set; get; } = 0;
    /// <summary>
    ///     Name - a string that stores product name 
    /// </summary>
    public string Name { set; get; } = string.Empty;
}