namespace Fabric.Domain;
/// <summary>
/// Class Shipment is used to store information about shipment from Providers to Fabrics.
/// </summary>
public class Shipment
{
    /// <summary>
    /// Id is used to store the ID.
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Fabric is used to store the recipient information.
    /// </summary>
    public Fabric Fabric { get; set; } = new Fabric();
    /// <summary>
    /// Provider is used to store the sender information.
    /// </summary>
    public Provider Provider { get; set; } = new Provider();
    /// <summary>
    /// Date is used to store the information about date of shipment.
    /// </summary>
    public DateTime Date { get; set; }
    /// <summary>
    /// NumberOfGoods is used to store the information about amount of goods in shipment.
    /// </summary>
    public int NumberOfGoods { get; set; }
}
