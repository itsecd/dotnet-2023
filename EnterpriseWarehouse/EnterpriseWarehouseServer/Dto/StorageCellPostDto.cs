namespace EnterpriseWarehouseServer.Dto;

public class StorageCellPostDto
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