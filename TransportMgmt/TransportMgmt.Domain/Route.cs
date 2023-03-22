﻿namespace TransportMgmt.Domain;
/// <summary>
/// Class Route is used to store information about routes
/// </summary>
public class Route
{
    /// <summary>
    /// Unique key of route
    /// </summary>
    public int RouteId { get; set; } = 0;
    /// <summary>
    /// Route number
    /// </summary>
    public string RouteNumber { get; set; } = string.Empty;
    public Route() { }
    public Route(int routeId, string routeNumber)
    {
        RouteId = routeId;
        RouteNumber = routeNumber;
    }
}
