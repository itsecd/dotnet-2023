namespace PonrfDomain;

/// <summary>
/// Class PrivatizedBuilding describes sold buildings
/// </summary>
public class PrivatizedBuilding
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
    /// FirstCost is a original auction price
    /// </summary>
    public int FirstCost { get; set; }
    /// <summary>
    /// SecondCost is a final cost
    /// </summary>
    public int SecondCost { get; set; }

    public Customer? Customer { get; set; }
    public Auction? Auction { get; set; }
    public Building? Building { get; set; }

    public PrivatizedBuilding() { }
    public PrivatizedBuilding(int id, DateTime dateOfSale, int firstCost, int secondCost, Customer? customer, Auction? auction, Building? building)
    {
        Id = id;
        DateOfSale = dateOfSale;
        FirstCost = firstCost;
        SecondCost = secondCost;
        Customer = customer;
        Auction = auction;
        Building = building;
    }
}