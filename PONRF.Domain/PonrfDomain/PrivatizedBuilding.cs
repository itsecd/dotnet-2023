namespace PonrfDomain;

/// <summary>
/// Class PrivatizedBuilding describes sold buildings
/// </summary>
public class PrivatizedBuilding
{
    /// <summary>
    /// Id is a identifier of privatized building
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// DateOfSale contains information about date of sale of the building
    /// </summary>
    public DateTime DateOfSale { get; set; } = DateTime.MinValue;
    /// <summary>
    /// FirstCost is a original auction price
    /// </summary>
    public int FirstCost { get; set; } = int.MinValue;
    /// <summary>
    /// SecondCost is a final cost
    /// </summary>
    public int SecondCost { get; set; } = int.MinValue;

    public Customer? Customer { get; set; } = new();
    public Auction? Auction { get; set; } = new();
    public Building? Building { get; set; } = new();

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