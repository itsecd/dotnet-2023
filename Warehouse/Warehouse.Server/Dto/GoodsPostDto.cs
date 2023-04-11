namespace Warehouse.Server.Dto;
public class GoodsPostDto
{
    /// <summary>
    ///     ProductCount - shows amount of product
    /// </summary>  
    public int ProductCount { set; get; }
    /// <summary>
    ///     Name - a string that stores product name 
    /// </summary>
    public string Name { set; get; } = string.Empty;
}