namespace EnterpriseWarehouse.Server.Dto;

/// <summary>
///     ProductPostDto - used to present Product object data in a post-query
/// </summary>
public class ProductPostDto
{
    /// <summary>
    ///     ItemNumber - unique identifier of the product
    /// </summary>
    public int ItemNumber { get; set; }

    /// <summary>
    ///     Title - product name
    /// </summary>
	public string Title { get; set; } = string.Empty;

    /// <summary>
    ///     Quantity - quantity of goods stored in the warehouse
    /// </summary>
	public int Quantity { get; set; }
}