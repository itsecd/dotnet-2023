namespace TransManagment;

public class Routes
{
    /// <summary>
    /// route_id - unique key of route
    /// </summary>
    public int Route_id { get; set; } = 0;
    /// <summary>
    /// date - date of route
    /// </summary>
    public DateOnly Date { get; set; } = new DateOnly();
    /// <summary>
    /// time_to - time when transport drive out of route
    /// </summary>
    public DateTime Time_to { get; set; } = new DateTime();
    /// <summary>
    /// time_from - time when transport drive in of route
    /// </summary>
    public DateTime Time_from { get; set; } = new DateTime();
    /// <summary>
    /// Transport - transport
    /// </summary>
    public Transports Transport  { get; set; } = new Transports();
    /// <summary>
    /// Driver - driver
    /// </summary>
    public Drivers Driver { get; set; } = new Drivers();
    public Routes() { }
    public Routes(int _route_id, DateOnly _date, DateTime _time_to, DateTime _time_from, Transports _transport, Drivers _driver)
	{
        Route_id = _route_id;
        Date = _date;
        Time_to = _time_to;
        Time_from = _time_from;
        Transport = _transport;
        Driver = _driver;
    }
}
