namespace TransportManagment.Classes;
public class Transport
{
    /// <summary>
    /// Unique key of transport
    /// </summary>
    public int TransportId { get; set; } = 0;
    /// <summary>
    /// type of transport
    /// </summary>
    public string Type { get; set; } = string.Empty;
    /// <summary>
    /// Model of transport
    /// </summary>
    public string Model { get; set; } = string.Empty;
    /// <summary>
    /// Date when make transport
    /// </summary>
    public DateOnly DateMake { get; set; } = new DateOnly();
    public Transport() { }
    public Transport(int transportId, string type, string model, DateOnly dateMake)
    {
        DateMake = dateMake;
        Type = type;
        Model = model;
        TransportId = transportId;
    }
}