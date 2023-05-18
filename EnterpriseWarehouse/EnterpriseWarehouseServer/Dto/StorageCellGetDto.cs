namespace EnterpriseWarehouseServer.Dto;

/// <summary>
///     StorageCellGetDto - used to represent the StorageCell object in the get-request
/// </summary>
public class StorageCellGetDto
{
    /// <summary>
    ///     Number - cell number
    /// </summary>
    public uint Number { get; set; }

    /// <summary>
    ///     ItemNumberProduct - unique identifier of the product 
    /// </summary>
	public uint ItemNumberProducts { get; set; }
}