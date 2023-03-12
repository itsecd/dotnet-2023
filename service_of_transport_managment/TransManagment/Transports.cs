namespace TransManagment;

public class Transports
{
    /// <summary>
    /// transport_id - unique key of transport
    /// </summary>
    public int Transport_id { get; set; } = 0;
    /// <summary>
    /// type - type of transport
    /// </summary>
    public string Type { get; set; } = string.Empty;
    /// <summary>
    /// model - model of transport
    /// </summary>
    public string Model { get; set; } = string.Empty;
    /// <summary>
    /// date_make - date when make transport
    /// </summary>
    public DateOnly? Date_make { get; set; } //= new DateOnly();
    public Transports() { }
    public Transports(int _transport_id, string _type, string _model, DateOnly _date_make)
	{
        Date_make = _date_make;
        Type = _type;
        Model = _model; 
        Transport_id = _transport_id;
    }
}
