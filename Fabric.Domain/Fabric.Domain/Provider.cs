namespace Fabric.Domain;
/// <summary>
/// Class Provider is used to store information of the provider.
/// </summary>
public class Provider
{
    /// <summary>
    /// Id is used to store the ID.
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Name is used to store name of Provider.
    /// </summary>
    public string Name { get; set; } = string.Empty;
    /// <summary>
    /// TypeOfGoods is used to store product type information.
    /// </summary>
    public string TypeOfGoods { get; set; } = string.Empty;
    /// <summary>
    /// PhoneNumber is used to store phone number of Fabric.
    /// </summary>
    public string Address { get; set; } = string.Empty;

    public List<Shipment> Shipments { get; set; } = new List<Shipment>();
    public Provider() { }
    public Provider(int id, string name, string typeOfGoods, string address, List<Shipment> shipments)
    {
        Id = id;
        Name = name;
        TypeOfGoods = typeOfGoods;
        Address = address;
        Shipments = shipments;
    }
}

