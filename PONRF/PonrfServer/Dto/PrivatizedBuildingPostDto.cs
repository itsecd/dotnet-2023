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
}