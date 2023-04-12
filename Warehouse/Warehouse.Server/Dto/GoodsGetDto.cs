namespace Warehouse.Server.Dto;
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