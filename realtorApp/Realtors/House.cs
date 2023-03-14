namespace Realtors;
public class House
{
    /// <summary>
    /// Id - guid typed value for storing Id of the houses
    /// </summary>
    public Guid Id{get; set;}=Guid.Empty;
    /// <summary>
    /// Type - a string type of object for sale - residential or non-residential
    /// </summary>
    public string Type{get;set;} = string.Empty;
    /// <summary>
    /// Address - a string for address of the property being sold
    /// </summary>
    public string Address{get;set;}=string.Empty;
    /// <summary>
    /// Square - uint value for object area
    /// </summary>
    public uint Square{get;set;}=uint.MinValue;
    /// <summary>
    /// Rooms - uint value for storing an amount of rooms of this type
    /// </summary>
    public uint Rooms{get;set;}=uint.MinValue;
    public House(){}
    public House(Guid id, string type, string address, uint square, uint rooms)
    {
        Id=id;
        Type=type;
        Address=address;
        Square = square;
        Rooms =rooms;
    }
    public override bool Equals(object? obj)
    {
        if(obj is not House param) return false;
        return Id == param.Id && Type==param.Type && Address==param.Address && Square==param.Square && Rooms==param.Rooms;
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(Id, Type, Address, Square, Rooms);
    }
}