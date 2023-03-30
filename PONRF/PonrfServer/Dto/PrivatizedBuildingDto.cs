using PonrfDomain;

namespace PonrfServer.Dto;

public class PrivatizedBuildingDto
{
    public int Id { get; set; }
    public DateTime DateOfSale { get; set; }
    public int FirstCost { get; set; }
    public int SecondCost { get; set; }

    public Customer? Customer { get; set; }
    public AuctionDto? Auction { get; set; }
    public BuildingDto? Building { get; set; }
}