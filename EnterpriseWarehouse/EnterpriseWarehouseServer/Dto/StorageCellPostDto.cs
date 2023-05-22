namespace EnterpriseWarehouseServer.Dto;

/// <summary>
///     StorageCellPostDto - used to present StorageCell object data in a post-query
/// </summary>
public class StorageCellPostDto
{
    /// <summary>
    ///     Number - cell number
    /// </summary>
    public uint Number { get; set; }

    /// <summary>
    ///     ItemNumberProduct - unique identifier of the product 
    /// </summary>
	public uint ItemNumberProduct { get; set; }
}