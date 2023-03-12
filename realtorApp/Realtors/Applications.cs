namespace Realtors;
public class Application
{
    public Guid ID{get; set;}=Guid.Empty;
    public string Type{get;set;} = string.Empty;
    public uint Cost{get;set;}=uint.MinValue;
    public DateTime Data{get;set;}=DateTime.MinValue;
    
    public List<House> Houses{get;set;}=new();
      
    public Application(){}
    public Application(Guid id, House house, string type, uint cost, DateTime data)
    {
        ID=id;
        Type=type;
        Cost=cost;
        Data = data;
        Houses=house;
    }
    public override bool Equals(object? obj)
    {
        if(obj is not Application param) return false;
        return Houses.Equals(param.Houses) && ID == param.ID && Type==param.Type && Cost==param.Cost && Data==param.Data;
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(Id, Type, Cost, Data, Houses);
    }
}