namespace EnterpriseWarehouse.Server.Dto;

/// <summary>
///     StorageCellGetDto - used to represent the StorageCell object in the get-request
/// </summary>
public class StorageCellGetDto
{
    /// <summary>
    ///     Number - cell number
    /// </summary>
    public int Number { get; set; }

    /// <summary>
    ///     ProductIN - unique identifier of the product 
    /// </summary>
	public int ProductIN { get; set; }
}