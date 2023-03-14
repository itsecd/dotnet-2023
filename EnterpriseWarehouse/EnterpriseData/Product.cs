namespace EnterpriseData;

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
    ///     QuntityProduct - quantity of goods stored in the warehouse
    /// </summary>
	public uint QuntityProduct { get; set; }

    /// <summary>
    ///     CellNumber - number of the cell in which the product is stored
    /// </summary>
	public uint CellNumber { get; set; }

	public Product(uint itemNumber, string title, uint quntityProduct, uint cellNumber)
    {
        ItemNumber = itemNumber;
        Title = title;
        QuntityProduct = quntityProduct;
        CellNumber = cellNumber;
    }
}
