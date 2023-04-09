namespace PonrfServer.Dto;

/// <summary>
/// PrivatizedBuildingGetDto for HTTP GET request
/// </summary>
public class PrivatizedBuildingGetDto
{
    /// <summary>
    /// Id is an identifier of privatized building
    /// </summary>
    public int Id { get; set; }
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
    /// Information about customer
    /// </summary>
    public CustomerGetDto? Customer { get; set; }
    /// <summary>
    /// Information about auction
    /// </summary>
    public AuctionGetDto? Auction { get; set; }
    /// <summary>
    /// Information about building
    /// </summary>
    public BuildingGetDto? Building { get; set; }
}