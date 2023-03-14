namespace Realtors;
public class Application
{
    /// <summary>
    /// Id - guid typed value for storing Id of the room
    /// </summary>
    public Guid Id{get; set;}=Guid.Empty;
    /// <summary>
    /// Type - string typed value representing a type of the room
    /// </summary>
    public string Type{get;set;} = string.Empty;
    /// <summary>
    /// Cost - uint for storing a cost of the room
    /// </summary>
    public uint Cost{get;set;}=uint.MinValue;
    /// <summary>
    /// Data - DateTime typed value for storing a date of application
    /// </summary>
    public DateTime Data{get;set;}=DateTime.MinValue;
    public List<House> Houses{get;set;}=new();
    public Application(){}
    public Application(Guid id, House house, string type, uint cost, DateTime data)
    {
        Id=id;
        Type=type;
        Cost=cost;
        Data = data;
        Houses=house;
    }
    public override bool Equals(object? obj)
    {
        if(obj is not Application param) return false;
        return Houses.Equals(param.Houses) && Id == param.Id && Type==param.Type && Cost==param.Cost && Data==param.Data;
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(Id, Type, Cost, Data, Houses);
    }
}