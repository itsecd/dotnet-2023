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
    /// FabricId is used to store the ID of recipient.
    /// </summary>
    public int FabricId { get; set; } = 0;
    /// <summary>
    /// ProviderId is used to store the ID of sender.
    /// </summary>
    public int ProviderId { get; set; } = 0;
    /// <summary>
    /// Date is used to store the information about date of shipment.
    /// </summary>
    public DateTime Date { get; set; }
    /// <summary>
    /// NumberOfGoods is used to store the information about amount of goods in shipment.
    /// </summary>
    public int NumberOfGoods { get; set; }

    public Shipment() { }
    public Shipment(int id, int fabricId, int providerId, DateTime date, int numberOfGoods)
    {
        Id = id;
        FabricId = fabricId;
        ProviderId = providerId;
        Date = date;
        NumberOfGoods = numberOfGoods;
    }
}
