namespace Realtors;
public class House
{
    public Guid ID{get; set;}=Guid.Empty;
    public string Type{get;set;} = string.Empty;
    public string Address{get;set;}=string.Empty;
    public uint Square{get;set;}=uint.MinValue;
    public uint Rooms{get;set;}=uint.MinValue;
    public House(){}
    public House(Guid id, string type, string address, uint square, uint rooms)
    {
        ID=id;
        Type=type;
        Address=address;
        Square = square;
        Rooms =rooms;
    }
    public override bool Equals(object? obj)
    {
        if(obj is not House param) return false;
        return ID == param.ID && Type==param.Type && Address==param.Address && Square==param.Square && Rooms==param.Rooms;
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(Id, Type, Address, Square, Rooms);
    }
}