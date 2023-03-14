namespace Enterprise.Data;

/// <summary>
///     StorageCell - is a class linking the cell number and the product stored in it
/// </summary>
public class StorageCell
{
    /// <summary>
    ///     Number - cell number
    /// </summary>
    public uint Number { get; set; }

    /// <summary>
    ///     ItemNumberProduct - unique identifier of the product 
    /// </summary>
	public List<uint> ItemNumberProducts { get; set; } = new List<uint>();

    public StorageCell(uint number, List<uint> itemNumberProducts)
    {
        Number = number;
        ItemNumberProducts = itemNumberProducts;
    }
}