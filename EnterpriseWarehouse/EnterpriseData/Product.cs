namespace Enterprise.Data;

/// <summary>
///     Product - is a class that stores information about a product
/// </summary>
public class Product
{
    /// <summary>
    ///     ItemNumber - unique identifier of the product
    /// </summary>
    public uint ItemNumber { get; set; }

    /// <summary>
    ///     Title - product name
    /// </summary>
	public string Title { get; set; } = string.Empty;

    /// <summary>
    ///     Quantity - quantity of goods stored in the warehouse
    /// </summary>
	public uint Quantity { get; set; }

    /// <summary>
    ///     CellNumber - number of the cell in which the product is stored
    /// </summary>
	public List<uint> CellNumber { get; set; }

    public Product(uint itemNumber, string title, uint quantity, List<uint> cellNumber)
    {
        ItemNumber = itemNumber;
        Title = title;
        Quantity = quantity;
        CellNumber = cellNumber;
    }

}
