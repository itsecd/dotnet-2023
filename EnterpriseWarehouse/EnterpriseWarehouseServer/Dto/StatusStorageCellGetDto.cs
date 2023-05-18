namespace EnterpriseWarehouseServer.Dto;

/// <summary>
///     StatusStorageCellGetDto - used to represent the storage cell and product objects in the get-request
/// </summary>
public class StatusStorageCellGetDto
{
    /// <summary>
    ///     Number - cell number
    /// </summary>
    public uint Number { get; set; }

    /// <summary>
    ///     ItemNumberProduct - unique identifier of the product 
    /// </summary>
	public uint ItemNumberProducts { get; set; }

    /// <summary>
    ///     Title - product name
    /// </summary>
	public string Title { get; set; } = string.Empty;

    /// <summary>
    ///     Quantity - quantity of goods stored in the warehouse
    /// </summary>
	public uint Quantity { get; set; }
}
