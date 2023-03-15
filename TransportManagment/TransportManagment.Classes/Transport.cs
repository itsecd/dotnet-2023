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
    /// <summary>
    /// List of routes for this transport
    /// </summary>
    public List<int> Routes { get; set; } = new List<int>();
    public Transport() { }
    public Transport(int transportId, string type, string model, DateOnly dateMake, List<int> routes)
    {
        DateMake = dateMake;
        Type = type;
        Model = model;
        TransportId = transportId;
        Routes = routes;
    }
}