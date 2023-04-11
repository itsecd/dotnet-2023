namespace Warehouse.Server.Dto;
public class GoodsGetDto
{
    /// <summary>
    ///     ProductCount - shows amount of product
    /// </summary>  
    public int ProductCount { set; get; }
    /// <summary>  
    ///     Id - shows the product's id
    /// </summary>  
    public int Id { set; get; }
    /// <summary>
    ///     Name - a string that stores product name 
    /// </summary>
    public string Name { set; get; } = string.Empty;
}