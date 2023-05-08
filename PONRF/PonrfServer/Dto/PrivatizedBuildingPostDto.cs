namespace PonrfServer.Dto;

/// <summary>
/// PrivatizedBuildingPostDto for HTTP POST request
/// </summary>
public class PrivatizedBuildingPostDto
{
    /// <summary>
    /// DateOfSale contains information about date of sale of the building
    /// </summary>
    public DateTime DateOfSale { get; set; }
    /// <summary>
    /// FirstCost is an original auction price
    /// </summary>
    public int FirstCost { get; set; }
    /// <summary>
    /// SecondCost is a final cost
    /// </summary>
    public int SecondCost { get; set; }
    /// <summary>
    /// Information about customer (only id)
    /// </summary>
    public int? CustomerId { get; set; }
    /// <summary>
    /// Information about auction (only id)
    /// </summary>
    public int? AuctionId { get; set; }
    /// <summary>
    /// Information about building (only id)
    /// </summary>
    public int? BuildingId { get; set; }
}