namespace TransportMgmt.Domain;

public class Transport
{
    public int TransportId { get; set; } = 0;

    public string Type { get; set; } = string.Empty;

    public Model Model { get; set; }= new Model();

    public DateOnly DateMake { get; set; } = new DateOnly();

    public List<int> Routes { get; set; } = new List<int>();

    public Transport() { }

    public Transport(int transportId, string type, Model model, DateOnly dateMake)
    {
        TransportId = transportId;
        Type = type;
        Model = model;
        DateMake = dateMake;
    }
}
