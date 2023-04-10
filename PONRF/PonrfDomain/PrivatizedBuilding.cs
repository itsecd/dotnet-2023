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
    /// <summary>
    /// Information about customer
    /// </summary>
    public Customer? Customer { get; set; }
    /// <summary>
    /// Information about auction
    /// </summary>
    public Auction? Auction { get; set; }
    /// <summary>
    /// Information about building
    /// </summary>
    public Building? Building { get; set; }
    /// <summary>
    /// Constructor for PrivatizedBuilding
    /// </summary>
    public PrivatizedBuilding() { }
    /// <summary>
    /// Constructor for PrivatizedBuilding with parameters
    /// </summary>
    /// <param name="id"></param>
    /// <param name="dateOfSale"></param>
    /// <param name="firstCost"></param>
    /// <param name="secondCost"></param>
    /// <param name="customer"></param>
    /// <param name="auction"></param>
    /// <param name="building"></param>
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