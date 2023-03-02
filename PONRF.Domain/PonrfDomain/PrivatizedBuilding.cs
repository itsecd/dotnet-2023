namespace PonrfDomain;

/// <summary>
/// Class PrivatizedBuilding describes booked room in hotel
/// </summary>
public class PrivatizedBuilding
{
    /// <summary>
    /// Id is a identifier of privatized building
    /// </summary>
    public Guid Id { get; set; } = Guid.Empty;
    /// <summary>
    /// DateOfSale contains informatiom about date of sale of the building
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

    public Customer? Passport { get; set; } = new();
    public Auction? Auction { get; set; } = new();
    public Building? Building { get; set; } = new();

    public PrivatizedBuilding() { }
}