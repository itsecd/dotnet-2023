namespace Realtor;
public class House
{
    /// <summary>
    /// Id - guid typed value for storing Id of the houses
    /// </summary>
    public Guid Id { get; set; } = Guid.Empty;
    /// <summary>
    /// Type - a string type of object for sale - residential or non-residential
    /// </summary>
    public string Type { get; set; } = string.Empty;
    /// <summary>
    /// Address - a string for address of the property being sold
    /// </summary>
    public string Address { get; set; } = string.Empty;
    /// <summary>
    /// Square - uint value for object area
    /// </summary>
    public int Square { get; set; } = int.MinValue;
    /// <summary>
    /// Rooms - uint value for storing an amount of rooms of this type
    /// </summary>
    public int Rooms { get; set; } = int.MinValue;
    public List<Application> Applications { get; set; } = new();
    public House() { }
    public House(Guid id, string type, string address, int square, int rooms)
    {
        Id = id;
        Type = type;
        Address = address;
        Square = square;
        Rooms = rooms;
    }
}