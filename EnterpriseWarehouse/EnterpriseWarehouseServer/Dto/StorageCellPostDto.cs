namespace EnterpriseWarehouseServer.Dto;

/// <summary>
///     StorageCellPostDto - used to present StorageCell object data in a post-query
/// </summary>
public class StorageCellPostDto
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