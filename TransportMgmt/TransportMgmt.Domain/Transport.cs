namespace TransportMgmt.Domain;
/// <summary>
/// Class Transport is used to store information about transport
/// </summary>
public class Transport
{
    /// <summary>
    /// Unique key of transport
    /// </summary>
    public int TransportId { get; set; } = 0;
    /// <summary>
    /// Transport type
    /// </summary>
    public string Type { get; set; } = string.Empty;
    /// <summary>
    /// Transport model
    /// </summary>
    public Model Model { get; set; } = new Model();
    /// <summary>
    /// Transport production date
    /// </summary>
    public DateOnly DateMake { get; set; } = new DateOnly();
    public Transport() { }
    public Transport(int transportId, string type, Model model, DateOnly dateMake)
    {
        TransportId = transportId;
        Type = type;
        Model = model;
        DateMake = dateMake;
    }
}
