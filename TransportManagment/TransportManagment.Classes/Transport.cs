using System.ComponentModel.DataAnnotations;

namespace TransportManagment.Model;
/// <summary>
/// Class of transports
/// </summary>
public class Transport
{
    /// <summary>
    /// Unique key of transport
    /// </summary>
    [Key]
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
    public DateTime DateMake { get; set; } = new DateTime();
    /// <summary>
    /// List of routes for this transport
    /// </summary>
    public List<Route> Routes { get; set; } = new List<Route>();
    public Transport() { }
    public Transport(int transportId, string type, string model, DateTime dateMake)
    {
        DateMake = dateMake;
        Type = type;
        Model = model;
        TransportId = transportId;
    }
}