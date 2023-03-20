namespace TransportMgmt.Domain;

public class Transport
{
    public int TransportID { get; set; } = 0;

    public string Type { get; set; } = string.Empty;

    public string Model { get; set; } = string.Empty;

    public DateOnly DateMake { get; set; } = new DateOnly();

    public Transport() { }

    public Transport(int transportID, string type, string model, DateOnly dateMake)
    {
        TransportID = transportID;
        Type = type;
        Model = model;
        DateMake = dateMake;
    }
}
