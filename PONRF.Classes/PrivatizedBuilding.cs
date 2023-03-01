namespace PONRF.Classes;

/// <summary>
/// Class PrivatizedBuilding describes booked room in hotel
/// </summary>
public class PrivatizedBuilding
{
    /// <summary>
    /// Id is a identifier of privatized building
    /// </summary>
    public guid Id { get; set; } = guid.Empty;
    /// <summary>
    /// DateOfSale contains informatiom about date of sale of the building
    /// </summary>
    public DateTime DateOfSale { get; set; } = DateTime.MinValue;
    /// <summary>
    /// FirstCost is a original auction price
    /// </summary>
    public int FirstCost { get; set; } = int.Empty;
    /// <summary>
    /// SecondCost is a final cost
    /// </summary>
    public int SecondCost { get; set; } = int.Empty;

    public Passport? Passport { get; set; } = None;
    public Auction? Auction { get; set; } = None;
    public RegistNumber? RegistNumber { get; set; } = None;

    public Building() { }
}