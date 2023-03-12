namespace Realtors;
public class Agencies
{
    public Guid ID{get; set;}=Guid.Empty;
    public string Name{get;set;} = string.Empty;

    public List<Client> Clients{get;set;}=new();
      
    public Agencies(){}
    public Agencies(Guid id, string name, Client client)
    {
        Clients=client;
        ID=id;
        Name=name;
    }
    public override bool Equals(object? obj)
    {
        if(obj is not Agencies param) return false;
        return Clients.Equals(param.Clients) && ID == param.ID && Name==param.Name;
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(Id, Name, Clients);
    }
}