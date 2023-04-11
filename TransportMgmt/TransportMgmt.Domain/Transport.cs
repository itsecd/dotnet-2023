namespace TransportMgmt.Domain;
/// <summary>
/// Class Transport is used to store information about transport
/// </summary>
public class Transport
{
    /// <summary>
    /// Unique key of transport
    /// </summary>
    public int Id { get; set; } = 0;
    /// <summary>
    /// Transport state number
    /// </summary>
    public string StateNumber { get; set; } = string.Empty;
    /// <summary>
    /// Transport type
    /// </summary>
    public TransportType Type { get; set; } = null!;
    /// <summary>
    /// Transport model 
    /// </summary>
    public Model Model { get; set; } = new Model();
    /// <summary>
    /// Transport production date
    /// </summary>
    public DateTime DateMake { get; set; } = new DateTime();
    public Transport() { }
    public Transport(int transportId, string stateNumber, TransportType type, Model model, DateTime dateMake)
    {
        Id = transportId;
        StateNumber = stateNumber;
        Type = type;
        Model = model;
        DateMake = dateMake;
    }
}
