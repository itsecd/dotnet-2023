namespace TransportMgmt.Domain;

public class Route
{
    public int RouteId { get; set; } = 0;

    public string RouteNumber { get; set; } = string.Empty;

    public Route() { }

    public Route(int routeId, string routeNumber)
    {
        RouteId = routeId;
        RouteNumber = routeNumber;
    }
}
